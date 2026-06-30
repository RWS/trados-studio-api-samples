using System;
using System.IO;
using TradosStudio.API.TranslationResources.Terminology;
using TradosStudio.API.TranslationResources.Terminology.Behaviours.Interfaces;

namespace FileGlossaryTerminologyProvider
{
	/// <summary>
	/// WinForms settings UI for the file glossary provider. It makes the provider selectable in the
	/// "Add Terminology Provider" dialog and supplies the browse/create/edit behaviours.
	/// Registered with the plugin container in <see cref="Plugin.RegisterTypes"/>.
	/// </summary>
	public class FileGlossaryTerminologyProviderWinFormsUI : ITerminologyProviderWinFormsUI
	{
		public string TypeName => StringResources.TypeName;

		public bool SupportsTerminologyProviderUri(Uri terminologyProviderUri)
		{
			return terminologyProviderUri != null
				&& string.Equals(terminologyProviderUri.Scheme, FileGlossaryTerminologyProvider.UriScheme, StringComparison.OrdinalIgnoreCase);
		}

		public TerminologyProviderDisplayInfo GetDisplayInfo(Uri terminologyProviderUri)
		{
			var name = StringResources.Name;
			try
			{
				var path = FileGlossaryTerminologyProvider.UriToPath(terminologyProviderUri);
				if (!string.IsNullOrEmpty(path))
				{
					name = Path.GetFileNameWithoutExtension(path);
				}
			}
			catch
			{
				// Ignore: fall back to the default display name.
			}

			return new TerminologyProviderDisplayInfo
			{
				Name = name,
				TooltipText = StringResources.TooltipText
			};
		}

		public T GetBehaviour<T>() where T : ITerminologyProviderBehaviour
		{
			if (typeof(T) == typeof(IBrowseBehaviour))
			{
				return (T)(object)new FileGlossaryBrowseBehaviour();
			}

			if (typeof(T) == typeof(ICreateBehaviour))
			{
				return (T)(object)new FileGlossaryCreateBehaviour();
			}

			if (typeof(T) == typeof(IEditBehaviour))
			{
				return (T)(object)new FileGlossaryEditBehaviour();
			}

			return default(T);
		}
	}
}
