using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;

namespace Sdl.PackagesOperations.Sample
{
    [ViewPart(
        Id = "MyPackagesOperationsViewPartSample",
        Name = "Packages Operations ViewPart",
        Description = "View part to test the packages operations inside the projects view"
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

        private static readonly Lazy<PackagesControl> _control = new Lazy<PackagesControl>(() => new PackagesControl());
    }
}
