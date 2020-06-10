using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;

namespace Sdl.EditorOperations.Sample
{
    [ViewPart(
        Id = "MyEditorViewPart",
        Name = "My Editor View Part",
        Description = "Integrating a view part inside the editor view"
        )]
    [ViewPartLayout(typeof(EditorController), Dock = DockType.Bottom)]
    class MyEditorViewPart : AbstractViewPartController
    {
        protected override IUIControl GetContentControl()
        {
            return _control.Value;
        }

        protected override void Initialize()
        {
        }

        private static readonly Lazy<MyEditorViewPartControl> _control = new Lazy<MyEditorViewPartControl>(() => new MyEditorViewPartControl());
    }
}
