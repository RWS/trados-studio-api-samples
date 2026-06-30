using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace FileGlossaryTerminologyProvider
{
	/// <summary>
	/// Root object of a JSON glossary file.
	/// </summary>
	[DataContract]
	public class GlossaryFile
	{
		[DataMember(Name = "name", Order = 0)]
		public string Name { get; set; }

		[DataMember(Name = "description", Order = 1)]
		public string Description { get; set; }

		[DataMember(Name = "entries", Order = 2)]
		public List<GlossaryEntry> Entries { get; set; }
	}

	/// <summary>
	/// A single concept (entry) of the glossary, holding the terms for each language.
	/// </summary>
	[DataContract]
	public class GlossaryEntry
	{
		[DataMember(Name = "id", Order = 0)]
		public int Id { get; set; }

		[DataMember(Name = "languages", Order = 1)]
		public List<GlossaryLanguageTerms> Languages { get; set; }
	}

	/// <summary>
	/// The terms of a single language inside a glossary entry.
	/// </summary>
	[DataContract]
	public class GlossaryLanguageTerms
	{
		/// <summary>ISO language/culture code, e.g. "en-US".</summary>
		[DataMember(Name = "lang", Order = 0)]
		public string Lang { get; set; }

		/// <summary>Display name of the language, e.g. "English (United States)".</summary>
		[DataMember(Name = "name", Order = 1)]
		public string Name { get; set; }

		[DataMember(Name = "terms", Order = 2)]
		public List<string> Terms { get; set; }
	}

	/// <summary>
	/// In-memory representation of a JSON glossary file together with the helpers used by the
	/// terminology provider. Loading and saving use <see cref="DataContractJsonSerializer"/> so the
	/// sample stays free of third-party dependencies on .NET Framework.
	/// </summary>
	public class FileGlossary
	{
		public FileGlossary(string filePath, GlossaryFile content, DateTime lastWriteTimeUtc)
		{
			FilePath = filePath;
			Content = content;
			LastWriteTimeUtc = lastWriteTimeUtc;
		}

		public string FilePath { get; }

		public GlossaryFile Content { get; }

		/// <summary>UTC timestamp of the backing file when it was loaded; used to detect changes on disk.</summary>
		public DateTime LastWriteTimeUtc { get; private set; }

		public static FileGlossary Load(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new ArgumentNullException(nameof(filePath));
			}

			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException("Glossary file not found.", filePath);
			}

			var serializer = new DataContractJsonSerializer(typeof(GlossaryFile));
			GlossaryFile content;
			using (var stream = File.OpenRead(filePath))
			{
				content = serializer.ReadObject(stream) as GlossaryFile;
			}

			if (content == null)
			{
				content = new GlossaryFile();
			}

			if (content.Entries == null)
			{
				content.Entries = new List<GlossaryEntry>();
			}

			return new FileGlossary(filePath, content, File.GetLastWriteTimeUtc(filePath));
		}

		public static void Save(string filePath, GlossaryFile content)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new ArgumentNullException(nameof(filePath));
			}

			var serializer = new DataContractJsonSerializer(typeof(GlossaryFile));
			using (var stream = File.Create(filePath))
			{
				serializer.WriteObject(stream, content);
			}
		}

		/// <summary>Writes an empty glossary template to <paramref name="filePath"/>.</summary>
		public static void CreateEmpty(string filePath, string name)
		{
			var content = new GlossaryFile
			{
				Name = name,
				Description = "Created with the File Glossary terminology provider sample.",
				Entries = new List<GlossaryEntry>()
			};
			Save(filePath, content);
		}

		/// <summary>Returns the distinct languages (ISO code + display name) found in the glossary.</summary>
		public IList<GlossaryLanguageTerms> GetLanguages()
		{
			var seen = new Dictionary<string, GlossaryLanguageTerms>(StringComparer.OrdinalIgnoreCase);
			foreach (var entry in Content.Entries)
			{
				if (entry.Languages == null)
				{
					continue;
				}

				foreach (var language in entry.Languages)
				{
					if (string.IsNullOrEmpty(language.Lang) || seen.ContainsKey(language.Lang))
					{
						continue;
					}

					seen[language.Lang] = language;
				}
			}

			return seen.Values.ToList();
		}

		public GlossaryEntry GetEntry(int id)
		{
			return Content.Entries.FirstOrDefault(e => e.Id == id);
		}

		/// <summary>Returns the next available entry ID (one higher than the current maximum).</summary>
		public int NextId()
		{
			return Content.Entries.Count == 0 ? 1 : Content.Entries.Max(e => e.Id) + 1;
		}

		/// <summary>
		/// Adds a new entry or replaces the existing one with the same <see cref="GlossaryEntry.Id"/>,
		/// then persists the glossary to disk.
		/// </summary>
		public void AddOrUpdateEntry(GlossaryEntry entry)
		{
			var index = Content.Entries.FindIndex(e => e.Id == entry.Id);
			if (index >= 0)
			{
				Content.Entries[index] = entry;
			}
			else
			{
				Content.Entries.Add(entry);
			}

			Save();
		}

		/// <summary>Persists the current in-memory content to disk and refreshes <see cref="LastWriteTimeUtc"/>.</summary>
		public void Save()
		{
			FileGlossary.Save(FilePath, Content);
			LastWriteTimeUtc = File.GetLastWriteTimeUtc(FilePath);
		}
	}
}
