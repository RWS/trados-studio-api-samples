using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Sdl.SDK.LanguagePlatform.Samples.BatchImporter
{
	/// <summary>
	/// Resolves Trados Studio dependencies from the Studio installation folder.
	/// Handles both managed assemblies (via <see cref="AppDomain.AssemblyResolve"/>)
	/// and native DLLs (via <c>AddDllDirectory</c>).
	/// </summary>
	public static class StudioAssemblyResolver
	{
		private static readonly string StudioInstallPath =
			Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
				@"Trados\Trados Studio\Studio19Beta");

		private const int LOAD_LIBRARY_SEARCH_DEFAULT_DIRS = 0x00001000;

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern IntPtr AddDllDirectory(string newDirectory);

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SetDefaultDllDirectories(int directoryFlags);

		/// <summary>
		/// Registers the assembly resolve handler on the current AppDomain
		/// and adds the Studio install folder to the native DLL search path.
		/// Call this once at application startup before any Studio types are used.
		/// </summary>
		public static void Register()
		{
			AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;

			if (Directory.Exists(StudioInstallPath))
			{
				// Enable the default set of search directories (application dir,
				// System32, and user-added dirs) so AddDllDirectory takes effect
				// for all subsequent native loads.
				SetDefaultDllDirectories(LOAD_LIBRARY_SEARCH_DEFAULT_DIRS);

				// Append the Studio folder — does not replace any existing paths.
				AddDllDirectory(StudioInstallPath);
			}
		}

		private static Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
		{
			var assemblyName = new AssemblyName(args.Name);
			string candidatePath = Path.Combine(StudioInstallPath, assemblyName.Name + ".dll");

			if (File.Exists(candidatePath))
			{
				return Assembly.LoadFrom(candidatePath);
			}

			return null;
		}
	}
}