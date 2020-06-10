using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;

namespace Sdl.FilesOperations.Sample
{
    [ViewPart(
        Id = "MyFilesViewPart",
        Name = "My Files View Part",
        Description = "Integrating a view part inside the files view"
        )]
    [ViewPartLayout(typeof(FilesController), Dock = DockType.Bottom)]
    class MyFilesViewPart : AbstractViewPartController
    {
        protected override IUIControl GetContentControl()
        {
            return _control.Value;
        }

        protected override void Initialize()
        {
        }

        private static readonly Lazy<MyFilesViewPartControl> _control = new Lazy<MyFilesViewPartControl>(() => new MyFilesViewPartControl());
    }
}
