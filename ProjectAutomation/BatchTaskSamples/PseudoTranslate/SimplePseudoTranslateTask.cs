using Sdl.FileTypeSupport.Framework.Core.Utilities.BilingualApi;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.ProjectAutomation.AutomaticTasks;
using Sdl.ProjectAutomation.Core;

namespace Sdl.SDK.BatchTasks.Samples.PseudoTranslation
{
    [AutomaticTask("sdk_sample_SimplePseudoTranslate",
        "Plugin_Name",
        "Plugin_Description",
        GeneratedFileType = AutomaticTaskFileType.BilingualTarget)]
    [AutomaticTaskSupportedFileType(AutomaticTaskFileType.BilingualTarget)]
    [RequiresSettings(typeof(SimplePseudoTranslateSettings), typeof(SimplePseudoTranslateSettingsPage))]
    public class SimplePseudoTranslateTask : AbstractFileContentProcessingAutomaticTask
    {
        private SimplePsedoTranslateProcessor _processor;

        protected override void ConfigureConverter(ProjectFile projectFile, IMultiFileConverter multiFileConverter)
        {
            if (_processor == null)
            {
                _processor = new SimplePsedoTranslateProcessor();
                var settings = GetSetting<SimplePseudoTranslateSettings>();
                _processor.Settings = settings;
            }
            multiFileConverter.AddBilingualProcessor(new BilingualContentHandlerAdapter(_processor));
        }

        public override bool OnFileComplete(ProjectFile projectFile, IMultiFileConverter multiFileConverter)
        {
            return true;
        }
    }
}


