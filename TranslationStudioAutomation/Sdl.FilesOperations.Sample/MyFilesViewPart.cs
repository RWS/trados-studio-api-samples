using System;
using System.Windows.Forms;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi;

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
        protected override Control GetContentControl()
        {
            return _control.Value;
        }

        protected override void Initialize()
        {            
        }

        private FilesController FilesController
        {
            get { return SdlTradosStudio.Application.GetController<FilesController>(); }
        }

        private static readonly Lazy<MyFilesViewPartControl> _control = new Lazy<MyFilesViewPartControl>(() => new MyFilesViewPartControl());                        
    }
}
