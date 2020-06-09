using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using System;

namespace Sdl.ViewParts.Sample
{
    [ViewPart(
        Id = "MyCustomViewPart2",
        Name = "My Custom ViewPart 2",
        Description = "This is a sample of viewpart.")]
    [ViewPartLayout(Dock = DockType.Bottom, LocationByType = typeof(MyViewWithParts), ZIndex = 1)]
    public class MyCustomViewPart2 : AbstractViewPartController
    {
        protected override IUIControl GetContentControl()
        {
            return _control.Value;
        }

        protected override void Initialize()
        {
        }

        private readonly Lazy<MyCustomViewPart2Control> _control = new Lazy<MyCustomViewPart2Control>(() => new MyCustomViewPart2Control());
    }
}
