using System;
using TradosStudio.API.TranslationResources.Terminology;

namespace FileGlossaryTerminologyProvider
{
	/// <summary>
	/// Creates <see cref="FileGlossaryTerminologyProvider"/> instances for URIs that use the
	/// <see cref="FileGlossaryTerminologyProvider.UriScheme"/> scheme. Registered with the plugin
	/// container in <see cref="Plugin.RegisterTypes"/>.
	/// </summary>
	public class FileGlossaryTerminologyProviderFactory : ITerminologyProviderFactory
	{
		public bool SupportsTerminologyProviderUri(Uri terminologyProviderUri)
		{
			return terminologyProviderUri != null
				&& string.Equals(terminologyProviderUri.Scheme, FileGlossaryTerminologyProvider.UriScheme, StringComparison.OrdinalIgnoreCase);
		}

		public ITerminologyProvider CreateTerminologyProvider(Uri terminologyProviderUri)
		{
			if (!SupportsTerminologyProviderUri(terminologyProviderUri))
				return null;

			var provider = new FileGlossaryTerminologyProvider(terminologyProviderUri);
			provider.Initialize();
			return provider;
		}
	}
}
