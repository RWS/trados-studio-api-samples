using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;

namespace Sdl.SegmentOperations.Sample
{
    [ViewPart(
        Id = "MySegmentOperationsPart",
        Name = "My Segment Operations View Part",
        Description = "Performing segment operations"
        )]
    [ViewPartLayout(typeof(EditorController), Dock = DockType.Bottom)]
    class MySegmentOperationsViewPart : AbstractViewPartController
    {
        protected override IUIControl GetContentControl()
        {
            return _control.Value;
        }

        protected override void Initialize()
        {
        }

        private static readonly Lazy<MySegmentOperationsViewPartControl> _control = new Lazy<MySegmentOperationsViewPartControl>(() => new MySegmentOperationsViewPartControl());
    }
}
