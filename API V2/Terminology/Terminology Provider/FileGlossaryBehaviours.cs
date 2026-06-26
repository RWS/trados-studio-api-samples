using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TradosStudio.API.TranslationResources.Terminology;
using TradosStudio.API.TranslationResources.Terminology.Behaviours.Interfaces;

namespace FileGlossaryTerminologyProvider
{
	/// <summary>
	/// Lets the user pick one or more existing JSON glossary files and turns them into providers.
	/// Invoked from the "Add Terminology Provider" dialog.
	/// </summary>
	public class FileGlossaryBrowseBehaviour : IBrowseBehaviour
	{
		public IEnumerable<ITerminologyProvider> Browse(IntPtr ownerHandle)
		{
			using (var dialog = new OpenFileDialog
			{
				Title = "Select one or more JSON glossary files",
				Filter = "JSON glossary (*.json)|*.json|All files (*.*)|*.*",
				CheckFileExists = true,
				Multiselect = true
			})
			{
				if (dialog.ShowDialog(new Win32Window(ownerHandle)) != DialogResult.OK)
					return Enumerable.Empty<ITerminologyProvider>();

				var providers = new List<ITerminologyProvider>();
				foreach (var fileName in dialog.FileNames)
				{
					var provider = new FileGlossaryTerminologyProvider(FileGlossaryTerminologyProvider.PathToUri(fileName));
					provider.Initialize();
					providers.Add(provider);
				}

				return providers;
			}
		}
	}

	/// <summary>
	/// Creates a new (empty) JSON glossary file and returns a provider for it.
	/// </summary>
	public class FileGlossaryCreateBehaviour : ICreateBehaviour
	{
		public ITerminologyProvider Create()
		{
			using (var dialog = new SaveFileDialog
			{
				Title = "Create a new JSON glossary file",
				Filter = "JSON glossary (*.json)|*.json",
				DefaultExt = "json",
				AddExtension = true,
				OverwritePrompt = true
			})
			{
				if (dialog.ShowDialog() != DialogResult.OK)
					return null;

				FileGlossary.CreateEmpty(dialog.FileName, Path.GetFileNameWithoutExtension(dialog.FileName));

				var provider = new FileGlossaryTerminologyProvider(FileGlossaryTerminologyProvider.PathToUri(dialog.FileName));
				provider.Initialize();
				return provider;
			}
		}
	}

	/// <summary>
	/// Lets the user re-point an existing provider to a different JSON glossary file.
	/// </summary>
	public class FileGlossaryEditBehaviour : IEditBehaviour
	{
		public bool Edit(IntPtr ownerHandle, ITerminologyProvider terminologyProvider)
		{
			if (!(terminologyProvider is FileGlossaryTerminologyProvider provider))
				return false;

			using (var dialog = new OpenFileDialog
			{
				Title = "Select the JSON glossary file",
				Filter = "JSON glossary (*.json)|*.json|All files (*.*)|*.*",
				CheckFileExists = true
			})
			{
				try
				{
					var currentPath = FileGlossaryTerminologyProvider.UriToPath(provider.Uri);
					if (!string.IsNullOrEmpty(currentPath) && File.Exists(currentPath))
					{
						dialog.InitialDirectory = Path.GetDirectoryName(currentPath);
						dialog.FileName = Path.GetFileName(currentPath);
					}
				}
				catch
				{
					// Ignore: fall back to the default dialog location.
				}

				if (dialog.ShowDialog(new Win32Window(ownerHandle)) != DialogResult.OK)
					return false;

				provider.SetBackingFile(dialog.FileName);
				return true;
			}
		}
	}

	/// <summary>
	/// Wraps a native window handle so WinForms dialogs can be shown modally over the Studio window.
	/// </summary>
	internal sealed class Win32Window : IWin32Window
	{
		public Win32Window(IntPtr handle)
		{
			Handle = handle;
		}

		public IntPtr Handle { get; }
	}
}
