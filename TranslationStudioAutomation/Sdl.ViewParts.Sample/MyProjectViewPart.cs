using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;
using System.Linq;

namespace Sdl.ViewParts.Sample
{
    [ViewPart(
        Id = "MyProjectViewPart",
        Name = "My Project View Part",
        Description = "Integrationg a view part inside the project view")]
    [ViewPartLayout(Dock = DockType.Bottom, LocationByType = typeof(ProjectsController))]
    class MyProjectViewPart : AbstractViewPartController
    {
        protected override IUIControl GetContentControl()
        {
            return _control.Value;
        }

        protected override void Initialize()
        {
            var projectController = SdlTradosStudio.Application.GetController<ProjectsController>();
            projectController.CurrentProjectChanged += (s, e) =>
                                                           {
                                                               if (projectController.CurrentProject == null)
                                                                   return;

                                                               _control.Value.CurrentProject = projectController.CurrentProject.FilePath;
                                                           };

            projectController.SelectedProjectsChanged += (s, e) =>
                                                             {
                                                                 _control.Value.SelectedProjectsCount = projectController.SelectedProjects.Count();
                                                             };
        }

        private static readonly Lazy<MyProjectViewPartControl> _control = new Lazy<MyProjectViewPartControl>(() => new MyProjectViewPartControl());
    }
}
