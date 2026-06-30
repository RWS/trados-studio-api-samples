using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Interop;
using Microsoft.Win32;
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
		public IEnumerable<ITerminologyProvider> Browse(IntPtr owner)
		{
			OpenFileDialog dialog = new OpenFileDialog
			{
				Title = StringResources.BrowseDialogTitle,
				Filter = StringResources.JsonGlossaryFilterWithAll,
				CheckFileExists = true,
				Multiselect = true
			};

			if (dialog.ShowDialog(NativeOwnerWindow.Create(owner)) != true)
				return Enumerable.Empty<ITerminologyProvider>();

			List<ITerminologyProvider> providers = new List<ITerminologyProvider>();
			foreach (var fileName in dialog.FileNames)
			{
				FileGlossaryTerminologyProvider provider = new FileGlossaryTerminologyProvider(FileGlossaryTerminologyProvider.PathToUri(fileName));
				provider.Initialize();
				providers.Add(provider);
			}

			return providers;
		}
	}

	/// <summary>
	/// Creates a new (empty) JSON glossary file and returns a provider for it.
	/// </summary>
	public class FileGlossaryCreateBehaviour : ICreateBehaviour
	{
		public ITerminologyProvider Create()
		{
			SaveFileDialog dialog = new SaveFileDialog
			{
				Title = StringResources.CreateDialogTitle,
				Filter = StringResources.CreateDialogFilter,
				DefaultExt = "json",
				AddExtension = true,
				OverwritePrompt = true
			};

			if (dialog.ShowDialog() != true)
				return null;

			FileGlossary.CreateEmpty(dialog.FileName, Path.GetFileNameWithoutExtension(dialog.FileName));

			FileGlossaryTerminologyProvider provider = new FileGlossaryTerminologyProvider(FileGlossaryTerminologyProvider.PathToUri(dialog.FileName));
			provider.Initialize();
			return provider;
		}
	}

	/// <summary>
	/// Lets the user re-point an existing provider to a different JSON glossary file.
	/// </summary>
	public class FileGlossaryEditBehaviour : IEditBehaviour
	{
		public bool Edit(IntPtr owner, ITerminologyProvider terminologyProvider)
		{
			if (!(terminologyProvider is FileGlossaryTerminologyProvider provider))
				return false;

			OpenFileDialog dialog = new OpenFileDialog
			{
				Title = StringResources.EditDialogTitle,
				Filter = StringResources.JsonGlossaryFilterWithAll,
				CheckFileExists = true
			};

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

			if (dialog.ShowDialog(NativeOwnerWindow.Create(owner)) != true)
				return false;

			provider.SetBackingFile(dialog.FileName);
			return true;
		}
	}

	/// <summary>
	/// Creates a hidden WPF <see cref="Window"/> that wraps a native window handle,
	/// so WPF file dialogs can be shown modally over the Studio window.
	/// </summary>
	internal static class NativeOwnerWindow
	{
		internal static Window Create(IntPtr handle)
		{
			Window window = new Window
			{
				Width = 0,
				Height = 0,
				WindowStyle = WindowStyle.None,
				ShowInTaskbar = false
			};
			WindowInteropHelper helper = new WindowInteropHelper(window);
			helper.EnsureHandle();
			if (handle != IntPtr.Zero)
				helper.Owner = handle;
			return window;
		}
	}
}
