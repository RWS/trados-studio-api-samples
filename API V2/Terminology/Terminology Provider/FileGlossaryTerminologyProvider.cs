using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TradosStudio.API.TranslationResources.Terminology;
using TradosStudio.API.TranslationResources.Terminology.Definition;
using TradosStudio.API.TranslationResources.Terminology.Entries;
using TradosStudio.API.TranslationResources.Terminology.Search;
using TermDefinition = TradosStudio.API.TranslationResources.Terminology.Definition.Definition;

namespace FileGlossaryTerminologyProvider
{
	/// <summary>
	/// A read-only terminology provider backed by a JSON glossary file on disk.
	/// </summary>
	public class FileGlossaryTerminologyProvider : ITerminologyProvider
	{
		/// <summary>Custom URI scheme that identifies providers handled by this plugin.</summary>
		public const string UriScheme = "fileglossary";

		private const string PathQueryKey = "path=";

		private string _filePath;
		private FileGlossary _glossary;
		private TermDefinition _definition;
		private bool _initialized;

		public FileGlossaryTerminologyProvider(Uri uri)
		{
			Uri = uri ?? throw new ArgumentNullException(nameof(uri));
			_filePath = UriToPath(uri);
		}

		public string Name => _glossary?.Content?.Name ?? SafeFileName(_filePath);

		public string Description => _glossary?.Content?.Description ?? string.Empty;

		public string Id => Uri.AbsoluteUri;

		public Uri Uri { get; private set; }

		public bool IsReadOnly => true;

		public bool SearchEnabled => true;

		public TermDefinition Definition => _definition;

		public FilterDefinition ActiveFilter { get; set; }

		public bool IsInitialized => _initialized;

		public bool Initialize()
		{
			if (_initialized)
				return true;

			_glossary = FileGlossary.Load(_filePath);
			_definition = BuildDefinition(_glossary);
			_initialized = true;
			return true;
		}

		public bool Uninitialize()
		{
			_glossary = null;
			_definition = null;
			_initialized = false;
			return true;
		}

		public void Dispose()
		{
			Uninitialize();
		}

		/// <summary>Returns whether the in-memory glossary still matches the file on disk.</summary>
		public bool IsProviderUpToDate()
		{
			if (_glossary == null)
				return false;

			try
			{
				return File.GetLastWriteTimeUtc(_filePath) <= _glossary.LastWriteTimeUtc;
			}
			catch
			{
				return false;
			}
		}

		public void SetDefault(bool isDefault)
		{
			// Read-only provider: nothing to persist.
		}

		public IList<FilterDefinition> GetFilters()
		{
			// Read-only sample provider: no filters are exposed.
			return new List<FilterDefinition>();
		}

		public IList<ILanguage> GetLanguages()
		{
			if (_glossary == null)
				return new List<ILanguage>();

			return _glossary.GetLanguages()
				.Select(language => (ILanguage)new GlossaryLanguage(language.Name ?? language.Lang, language.Lang))
				.ToList();
		}

		public Entry GetEntry(int id)
		{
			var glossaryEntry = _glossary?.GetEntry(id);
			if (glossaryEntry == null)
				return null;

			var entry = new Entry
			{
				Id = glossaryEntry.Id,
				Fields = new List<EntryField>(),
				Transactions = new List<EntryTransaction>(),
				Languages = new List<EntryLanguage>()
			};

			if (glossaryEntry.Languages != null)
			{
				foreach (var language in glossaryEntry.Languages)
				{
					var entryLanguage = new EntryLanguage
					{
						Name = language.Name ?? language.Lang,
						LanguageIsoCode = language.Lang,
						ParentEntry = entry,
						Fields = new List<EntryField>(),
						Terms = new List<EntryTerm>()
					};

					if (language.Terms != null)
					{
						foreach (var term in language.Terms)
						{
							entryLanguage.Terms.Add(new EntryTerm
							{
								Value = term,
								ParentLanguage = entryLanguage,
								Fields = new List<EntryField>(),
								Transactions = new List<EntryTransaction>()
							});
						}
					}

					entry.Languages.Add(entryLanguage);
				}
			}

			return entry;
		}

		public IList<SearchResult> Search(string text, ILanguage source, ILanguage target, int maxResults, SearchMode mode, bool targetRequired)
		{
			var results = new List<SearchResult>();
			if (!_initialized || _glossary == null || string.IsNullOrWhiteSpace(text))
				return results;

			var sourceIso = source?.LanguageIsoCode;
			if (string.IsNullOrEmpty(sourceIso))
				return results;

			var targetIso = target?.LanguageIsoCode;

			foreach (var entry in _glossary.Content.Entries)
			{
				var sourceLanguage = FindLanguage(entry, sourceIso);
				if (sourceLanguage?.Terms == null || sourceLanguage.Terms.Count == 0)
					continue;

				if (targetRequired)
				{
					var targetLanguage = FindLanguage(entry, targetIso);
					if (targetLanguage?.Terms == null || targetLanguage.Terms.Count == 0)
						continue;
				}

				string bestTerm = null;
				var bestScore = 0;
				foreach (var term in sourceLanguage.Terms)
				{
					var score = ComputeScore(text, term, mode);
					if (score > bestScore)
					{
						bestScore = score;
						bestTerm = term;
					}
				}

				if (bestTerm == null || bestScore <= 0)
					continue;

				results.Add(new SearchResult
				{
					Id = entry.Id,
					Text = bestTerm,
					Score = bestScore,
					Language = new GlossaryLanguage(sourceLanguage.Name ?? sourceLanguage.Lang, sourceLanguage.Lang)
				});
			}

			IEnumerable<SearchResult> ordered = results.OrderByDescending(r => r.Score);
			if (maxResults > 0)
				ordered = ordered.Take(maxResults);

			return ordered.ToList();
		}

		/// <summary>Re-points the provider to a different glossary file and reloads it.</summary>
		internal void SetBackingFile(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
				throw new ArgumentNullException(nameof(filePath));

			_filePath = Path.GetFullPath(filePath);
			Uri = PathToUri(_filePath);
			Uninitialize();
			Initialize();
		}

		private static TermDefinition BuildDefinition(FileGlossary glossary)
		{
			var languages = glossary.GetLanguages()
				.Select(language => new DefinitionLanguage
				{
					Name = language.Name ?? language.Lang,
					LanguageIsoCode = language.Lang
				})
				.ToList();

			var fields = new List<DescriptiveField>
			{
				new DescriptiveField
				{
					Label = "Definition",
					Type = FieldType.String,
					Level = FieldLevel.LanguageLevel,
					Mandatory = false,
					Multiple = false,
					ShowInUI = true,
					PickListValues = new List<string>()
				}
			};

			return new TermDefinition(fields, languages);
		}

		private static GlossaryLanguageTerms FindLanguage(GlossaryEntry entry, string isoCode)
		{
			if (entry.Languages == null || string.IsNullOrEmpty(isoCode))
				return null;

			return entry.Languages.FirstOrDefault(l => string.Equals(l.Lang, isoCode, StringComparison.OrdinalIgnoreCase));
		}

		private static int ComputeScore(string query, string term, SearchMode mode)
		{
			if (string.IsNullOrEmpty(term) || string.IsNullOrEmpty(query))
				return 0;

			var normalizedQuery = query.Trim();
			if (string.Equals(normalizedQuery, term, StringComparison.OrdinalIgnoreCase))
				return 100;

			var loweredQuery = normalizedQuery.ToLowerInvariant();
			var loweredTerm = term.ToLowerInvariant();

			if (loweredTerm.Contains(loweredQuery) || loweredQuery.Contains(loweredTerm))
			{
				var shorter = Math.Min(loweredQuery.Length, loweredTerm.Length);
				var longer = Math.Max(loweredQuery.Length, loweredTerm.Length);
				return Math.Max(50, (int)(shorter * 100.0 / longer));
			}

			if (mode == SearchMode.Fuzzy)
			{
				var distance = LevenshteinDistance(loweredQuery, loweredTerm);
				var longest = Math.Max(loweredQuery.Length, loweredTerm.Length);
				if (longest == 0)
					return 0;

				var score = (int)((1.0 - (double)distance / longest) * 100);
				return score >= 50 ? score : 0;
			}

			return 0;
		}

		private static int LevenshteinDistance(string a, string b)
		{
			if (string.IsNullOrEmpty(a))
				return string.IsNullOrEmpty(b) ? 0 : b.Length;
			if (string.IsNullOrEmpty(b))
				return a.Length;

			var previous = new int[b.Length + 1];
			var current = new int[b.Length + 1];

			for (var j = 0; j <= b.Length; j++)
				previous[j] = j;

			for (var i = 1; i <= a.Length; i++)
			{
				current[0] = i;
				for (var j = 1; j <= b.Length; j++)
				{
					var cost = a[i - 1] == b[j - 1] ? 0 : 1;
					current[j] = Math.Min(Math.Min(current[j - 1] + 1, previous[j] + 1), previous[j - 1] + cost);
				}

				var swap = previous;
				previous = current;
				current = swap;
			}

			return previous[b.Length];
		}

		private static string SafeFileName(string path)
		{
			try
			{
				return string.IsNullOrEmpty(path) ? "File Glossary" : Path.GetFileNameWithoutExtension(path);
			}
			catch
			{
				return "File Glossary";
			}
		}

		/// <summary>Builds a provider URI that embeds the glossary file path.</summary>
		public static Uri PathToUri(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
				throw new ArgumentNullException(nameof(filePath));

			var fullPath = Path.GetFullPath(filePath);
			return new Uri(UriScheme + "://glossary/?" + PathQueryKey + Uri.EscapeDataString(fullPath));
		}

		/// <summary>Extracts the glossary file path from a provider URI.</summary>
		public static string UriToPath(Uri uri)
		{
			if (uri == null)
				throw new ArgumentNullException(nameof(uri));

			var query = uri.Query ?? string.Empty;
			var index = query.IndexOf(PathQueryKey, StringComparison.OrdinalIgnoreCase);
			if (index < 0)
				return string.Empty;

			var value = query.Substring(index + PathQueryKey.Length);
			var ampersand = value.IndexOf('&');
			if (ampersand >= 0)
				value = value.Substring(0, ampersand);

			return Uri.UnescapeDataString(value);
		}
	}

	/// <summary>Minimal <see cref="ILanguage"/> implementation for search results and language lists.</summary>
	internal sealed class GlossaryLanguage : ILanguage
	{
		public GlossaryLanguage()
		{
		}

		public GlossaryLanguage(string name, string isoCode)
		{
			Name = name;
			LanguageIsoCode = isoCode;
		}

		public string Name { get; set; }

		public string LanguageIsoCode { get; set; }
	}
}
