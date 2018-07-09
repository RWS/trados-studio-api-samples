using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using System;

namespace Sdl.ViewParts.Sample
{
    [ViewPart(
        Id = "MyCustomViewPart1",
        Name = "My Custom ViewPart 1",
        Description = "This is a sample of viewpart.")]
    [ViewPartLayout(LocationByType = typeof(MyViewWithParts), ZIndex = 2, Dock = DockType.Bottom)]
    public class MyCustomViewPart1 : AbstractViewPartController
    {
        protected override System.Windows.Forms.Control GetContentControl()
        {
            return _control.Value;
        }

        protected override void Initialize()
        {
        }

        private readonly Lazy<MyCustomViewPart1Control> _control = new Lazy<MyCustomViewPart1Control>(() => new MyCustomViewPart1Control());
    }
}
