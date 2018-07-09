using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using System;

namespace Sdl.ViewParts.Sample
{
    [ViewPart(
        Id = "MyCustomViewPart3",
        Name = "My Custom ViewPart 3",
        Description = "This is a sample of viewpart.")]
    [ViewPartLayout(Dock = DockType.Bottom, LocationByType = typeof(MyViewWithParts), ZIndex = 3)]
    public class MyCustomViewPart3 : AbstractViewPartController
    {
        protected override System.Windows.Forms.Control GetContentControl()
        {
            return _control.Value;
        }

        protected override void Initialize()
        {
        }

        private readonly Lazy<MyCustomViewPart3Control> _control = new Lazy<MyCustomViewPart3Control>(() => new MyCustomViewPart3Control());
    }
}
