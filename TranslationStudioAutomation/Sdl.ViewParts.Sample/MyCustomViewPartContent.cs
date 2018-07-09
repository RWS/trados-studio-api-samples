using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using System;

namespace Sdl.ViewParts.Sample
{
    [ViewPart(
        Id = "MyCustomViewPartContent",
        Name = "My Custom ViewPart Content",
        Description = "This is a sample of viewpart content.")]
    [ViewPartLayout(Dock = DockType.Fill, LocationByType = typeof(MyViewWithParts))]
    public class MyCustomViewPartContent : AbstractViewPartController
    {
        protected override System.Windows.Forms.Control GetContentControl()
        {
            return _control.Value;
        }

        protected override void Initialize()
        {
        }

        private readonly Lazy<MyCustomViewPartContentControl> _control = new Lazy<MyCustomViewPartContentControl>(() => new MyCustomViewPartContentControl());
    }
}
