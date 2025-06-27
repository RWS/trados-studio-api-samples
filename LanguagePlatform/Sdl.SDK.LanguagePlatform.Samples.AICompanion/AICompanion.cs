using Sdl.LanguagePlatform.TranslationMemoryApi.AICompanion;
using Sdl.LanguagePlatform.TranslationMemoryApi.AICompanion.Model;
using Sdl.LanguagePlatform.TranslationMemoryApi.LiteBCM;
using Sdl.LanguagePlatform.TranslationMemoryApi.LiteBCM.Skeleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sdl.SDK.LanguagePlatform.Samples.AICompanion
{
    public class AICompanion : IAICompanion
    {
        private readonly AISettings _settings;

        public AICompanion() 
        {
            Name = PluginResources.Plugin_Name;
            _settings = new AISettings
            {
                AutoTranslateEnabled = false,
                Connections = new List<Connection>
                {
                    new Connection { Id = "1", Name =  "Connection 1" },
                    new Connection { Id = "2", Name = "Connection 2" },
                    new Connection { Id = "2", Name =  "Connection 3" }
                },
                Prompts = new List<Prompt>
                {
                    new Prompt { Id = "1", Name = "Default" },
                    new Prompt { Id = "2", Name = "Comments" },
                    new Prompt { Id = "3", Name = "Revisions" },
                    new Prompt { Id = "4", Name = "Terminology" }
                }
            };

            _settings.SelectedConnection = _settings.Connections[0];
            _settings.SelectedPrompt = _settings.Prompts[0];
        }


        public AISettings Settings => _settings;

        public string Name { get; set; }

        public bool DisplaySettingsControl(IWin32Window window, AISettingsDialogParams dialogParams)
        {
            var view = new AICompanionSettingsWindow();
            new System.Windows.Interop.WindowInteropHelper(view).Owner = window.Handle;
            var model = new AICompanionSettingsViewModel(view);
            model.AutoTranslate = _settings.AutoTranslateEnabled;
            view.DataContext = model;

            var saved = view.ShowDialog();
            if (saved == true)
            {
                _settings.AutoTranslateEnabled = model.AutoTranslate;
                return true;
            }

            return false;
        }

        public Task<AISearchResult> SearchAsync(AISearchParams aISearchParams)
        {
            var file = new File()
            {
                Skeleton = aISearchParams.SegmentPair.Skeleton,
            };

            var segmentPair = aISearchParams.SegmentPair;


            var output = new AISearchResult()
            {
                Result = new LiteDocument(Guid.NewGuid().ToString(), segmentPair.SourceLanguageCode, file)
            };

            var sourceContent = segmentPair.SourceContent as Paragraph;
            var sourceSegment = sourceContent.Children.FirstOrDefault() as Segment;

            if (sourceSegment is null)
            {
                return Task.FromResult(output);
            }

            List<Segment> segments = SegmentFactory.CreateSegments(aISearchParams, sourceSegment, file.Skeleton);
            foreach (var segment in segments) 
            {
                var paragraph = new Paragraph();
                paragraph.Add(segment);
                file.ParagraphUnits.Add(new ParagraphUnit(sourceContent, paragraph));
            }

            return Task.FromResult(output);
        }
    }
}
