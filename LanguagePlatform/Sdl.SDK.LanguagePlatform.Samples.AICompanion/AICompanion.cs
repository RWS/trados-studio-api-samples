using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sdl.LanguagePlatform.TranslationMemoryApi.AICompanion;
using Sdl.LanguagePlatform.TranslationMemoryApi.AICompanion.Model;
using TradosStudio.BcmLite;

namespace Sdl.SDK.LanguagePlatform.Samples.AICompanion
{
	public class AICompanion : IAICompanion
	{
		public AICompanion()
		{
			Name = PluginResources.Plugin_Name;
			Settings = new AISettings
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

			Settings.SelectedConnection = Settings.Connections[0];
			Settings.SelectedPrompt = Settings.Prompts[0];
		}


		public AISettings Settings { get; }

		public string Name { get; set; }

		public bool DisplaySettingsControl(IWin32Window owner, AISettingsDialogParams dialogParams)
		{
			var view = new AICompanionSettingsWindow();
			new System.Windows.Interop.WindowInteropHelper(view).Owner = owner.Handle;
			var model = new AICompanionSettingsViewModel(view);
			model.AutoTranslate = Settings.AutoTranslateEnabled;
			view.DataContext = model;

			var saved = view.ShowDialog();
			if (saved == true)
			{
				Settings.AutoTranslateEnabled = model.AutoTranslate;
				return true;
			}

			return false;
		}

		public Task<AISearchResult> SearchAsync(AISearchParams searchParams)
		{
			var file = new File()
			{
				Skeleton = searchParams.SegmentPair.Skeleton,
			};

			var segmentPair = searchParams.SegmentPair;


			var output = new AISearchResult()
			{
				Result = new Document(Guid.NewGuid().ToString(), segmentPair.SourceLanguageCode, file)
			};

			var sourceContent = segmentPair.SourceContent as Paragraph;
			var sourceSegment = sourceContent.Children.FirstOrDefault() as Segment;

			if (sourceSegment is null)
			{
				return Task.FromResult(output);
			}

			List<Segment> segments = SegmentFactory.CreateSegments(searchParams, sourceSegment, file.Skeleton);
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
