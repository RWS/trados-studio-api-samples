using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sdl.ViewParts.Sample
{
    public partial class MyCustomViewPartContentControl : UserControl, IUIControl
    {
        public MyCustomViewPartContentControl()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs paintEvent)
        {
            var controller1 = SdlTradosStudio.Application.GetController<MyCustomViewPart1>();
            MyCustomViewPart1State.Text = _activeStateText[controller1.IsActive];
            MyCustomViewPart1Button.Visible = !controller1.IsActive;
            MyCustomViewPart1Visibility.Text = _visibleStateText[controller1.IsVisible];
            controller1.ActivationChanged += (s, e) =>
                                                 {
                                                     MyCustomViewPart1State.Text = _activeStateText[e.Active];
                                                     MyCustomViewPart1Button.Visible = e.Active;
                                                 };
            controller1.VisibilityChanged += (s, e) => MyCustomViewPart1Visibility.Text = _visibleStateText[e.Visible];


            var controller2 = SdlTradosStudio.Application.GetController<MyCustomViewPart2>();
            MyCustomViewPart2State.Text = _activeStateText[controller2.IsActive];
            MyCustomViewPart2Button.Visible = !controller2.IsActive;
            MyCustomViewPart2Visibility.Text = _visibleStateText[controller2.IsVisible];
            controller2.ActivationChanged += (s, e) =>
                                                 {
                                                     MyCustomViewPart2State.Text = _activeStateText[e.Active];
                                                     MyCustomViewPart2Button.Visible = e.Active;
                                                 };
            controller2.VisibilityChanged += (s, e) => MyCustomViewPart2Visibility.Text = _visibleStateText[e.Visible];


            var controller3 = SdlTradosStudio.Application.GetController<MyCustomViewPart3>();
            MyCustomViewPart3State.Text = _activeStateText[controller3.IsActive];
            MyCustomViewPart3Button.Visible = !controller3.IsActive;
            MyCustomViewPart3Visibility.Text = _visibleStateText[controller3.IsVisible];
            controller3.ActivationChanged += (s, e) =>
                                                 {
                                                     MyCustomViewPart3State.Text = _activeStateText[e.Active];
                                                     MyCustomViewPart3Button.Visible = e.Active;
                                                 };
            controller3.VisibilityChanged += (s, e) => MyCustomViewPart3Visibility.Text = _visibleStateText[e.Visible];
        }

        private void MyCustomViewPart1Button_Click(object sender, EventArgs e)
        {
            SdlTradosStudio.Application.GetController<MyCustomViewPart1>().Activate();
        }

        private void MyCustomViewPart2Button_Click(object sender, EventArgs e)
        {
            SdlTradosStudio.Application.GetController<MyCustomViewPart2>().Activate();
        }

        private void MyCustomViewPart3Button_Click(object sender, EventArgs e)
        {
            SdlTradosStudio.Application.GetController<MyCustomViewPart3>().Activate();
        }

        private void ActivateProjectViewPartButton_Click(object sender, EventArgs e)
        {
            SdlTradosStudio.Application.GetController<ProjectsController>().Activate();
            SdlTradosStudio.Application.GetController<MyProjectViewPart>().Activate();
        }

        readonly Dictionary<bool, string> _visibleStateText = new Dictionary<bool, string>
                                {
                                    {true, "is visible"},
                                    {false, "is hidden"}
                                };
        readonly Dictionary<bool, string> _activeStateText = new Dictionary<bool, string>
                                {
                                    {true, "is active"},
                                    {false, "is inactive"}
                                };
    }
}
