using Sdl.Core.Settings;

namespace Sdl.SDK.BatchTasks.Samples.PseudoTranslation
{
    public class SimplePseudoTranslateSettings : SettingsGroup
    {
        internal const string SettingsIdTargetContent = "CopyTargetContent";
        internal const string SettingsIdAppendStart = "AppendStart";
        internal const string SettingsIdAppendEnd = "AppendEnd";
        internal const string SettingsIdChangeToDraft = "ChangeToDraft";

        public SimplePseudoTranslateSettings()
        {
        }

        public Setting<string> AppendStart
        {
            get { return GetSetting<string>(SettingsIdAppendStart); }
        }

        public Setting<string> AppendEnd
        {
            get { return GetSetting<string>(SettingsIdAppendEnd); }
        }

        public Setting<bool> CopyTargetContent
        {
            get { return GetSetting<bool>(SettingsIdTargetContent); }
        }

        public Setting<bool> ToSetDraft
        {
            get { return GetSetting<bool>(SettingsIdChangeToDraft); }
        }

        protected override object GetDefaultValue(string settingId)
        {
            switch (settingId)
            {
                case SettingsIdTargetContent:
                    return true;
                case SettingsIdAppendStart:
                    return "<<";
                case SettingsIdAppendEnd:
                    return ">>";
                case SettingsIdChangeToDraft:
                    return true;
                default:
                    return null;
            }
        }
    }
}
