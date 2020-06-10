using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;

namespace Sdl.ProjectsOperations.Sample
{
    [ViewPart(
        Id = "MyProjectsViewPartSample",
        Name = "My Projects View Part",
        Description = "Integrating a view part inside the projects view"
        )]
    [ViewPartLayout(typeof(ProjectsController), Dock = DockType.Bottom)]
    class MyEditorViewPart : AbstractViewPartController
    {
        protected override IUIControl GetContentControl()
        {
            return _control.Value;
        }

        protected override void Initialize()
        {
        }

        private static readonly Lazy<MyProjectsViewPartControl> _control = new Lazy<MyProjectsViewPartControl>(() => new MyProjectsViewPartControl());
    }
}
