using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using Sdl.Desktop.IntegrationApi;
using Sdl.ProjectAutomation.AutomaticTasks;

namespace Sdl.SDK.BatchTasks.Samples.PseudoTranslation
{
    public partial class SimplePseudoTranslateSettingsControl : UserControl, ISettingsAware<SimplePseudoTranslateSettings>
    {
        private SimplePseudoTranslateSettings _settings;
        public SimplePseudoTranslateSettingsControl()
        {
            InitializeComponent();
        }

        public SimplePseudoTranslateSettings Settings
        {
            get { return _settings; }

            set
            {
                _settings = value;
                
                SettingsBinder.DataBindSetting<bool>(
                    new RadioButton[] {radioButtonCopySource, radioButtonRandomText},
                    new bool[] {true, false},
                    _settings,
                    SimplePseudoTranslateSettings.SettingsIdTargetContent);

                SettingsBinder.DataBindSetting<string>(
                    textBoxAppendStart,
                    "Text",
                    _settings,
                    SimplePseudoTranslateSettings.SettingsIdAppendStart);

                SettingsBinder.DataBindSetting<string>(
                    textBoxAppendEnd,
                    "Text",
                    _settings,
                    SimplePseudoTranslateSettings.SettingsIdAppendEnd);

                SettingsBinder.DataBindSetting<bool>(
                    new RadioButton[] {radioButtonDraft, radioButtonNoChange},
                    new bool[] {true, false},
                    _settings,
                    SimplePseudoTranslateSettings.SettingsIdChangeToDraft);
            }
        }
    }
}
