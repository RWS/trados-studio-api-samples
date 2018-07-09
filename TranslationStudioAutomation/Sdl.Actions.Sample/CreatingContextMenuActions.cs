using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.Presentation.DefaultLocations;
using System;
using System.Windows.Forms;

namespace Sdl.Actions.Sample
{
	[Action("MyMainIconAction1", typeof(EditorController), Icon = "MyAction_Icon")]
	[ActionLayout(typeof(TranslationStudioDefaultContextMenus.EditorDocumentContextMenuLocation), 3, Desktop.IntegrationApi.Extensions.DisplayType.Default, "", true)]
	public class MyMainIconAction1 : AbstractAction
	{
		protected override void Execute()
		{
			MessageBox.Show("My icon and shortcut key action sample.");
		}
	}

	[Action("MyMainIconAction2", typeof(EditorController), Icon = "MyAction_Icon")]
	[ActionLayout(typeof(TranslationStudioDefaultContextMenus.EditorDocumentContextMenuLocation), 2)]
	public class MyMainIconAction2 : AbstractAction
	{
		protected override void Execute()
		{
			MessageBox.Show("My icon and shortcut key action sample.");
		}
	}

	[Action("MyMainIconAction3", typeof(EditorController), Icon = "MyAction_Icon")]
	[ActionLayout(typeof(TranslationStudioDefaultContextMenus.EditorDocumentContextMenuLocation), 1)]
	public class MyMainIconAction3 : AbstractAction
	{
		protected override void Execute()
		{
			MessageBox.Show("My icon and shortcut key action sample.");
		}
	}

	[Action("MyMainIconAction4", typeof(FilesController), Icon = "MyAction_Icon")]
	[ActionLayout(typeof(TranslationStudioDefaultContextMenus.ProjectsContextMenuLocation), 5, Desktop.IntegrationApi.Extensions.DisplayType.Default, "", true)]
	public class MyMainIconAction4 : AbstractAction
	{
		protected override void Execute()
		{
			MessageBox.Show("My icon and shortcut key action sample.");
		}
	}

	[Action("MyMainIconAction5", typeof(FilesController), Icon = "MyAction_Icon")]
	[ActionLayout(typeof(TranslationStudioDefaultContextMenus.ProjectsContextMenuLocation), 4)]
	public class MyMainIconAction5 : AbstractAction
	{
		protected override void Execute()
		{
			MessageBox.Show("My icon and shortcut key action sample.");
		}
	}

	[Action("MyMainIconAction6", typeof(FilesController), Icon = "MyAction_Icon")]
	[ActionLayout(typeof(TranslationStudioDefaultContextMenus.FilesContextMenuLocation), 0, Desktop.IntegrationApi.Extensions.DisplayType.Default, "", true)]
	public class MyMainIconAction6 : AbstractAction
	{
		protected override void Execute()
		{
			MessageBox.Show("My icon and shortcut key action sample.");
		}
	}
}
