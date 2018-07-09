using Sdl.Core.Globalization;
using Sdl.FileTypeSupport.Framework.BilingualApi;

namespace Sdl.SDK.BatchTasks.Samples.PseudoTranslation
{
    class SimplePsedoTranslateProcessor : AbstractBilingualContentHandler
    {
        private int _lcid;
        private ISegment _processedSegment;
        private bool _isFirstWord = false;
        volatile bool _cancelRequested = false;
        private int _maximumSegmentLength;

        public SimplePsedoTranslateProcessor()
        {

        }

        public SimplePseudoTranslateSettings Settings { get; set; }

        public override void ProcessParagraphUnit(IParagraphUnit paragraphUnit)
        {
            // ignore structure segment
            if (!paragraphUnit.IsStructure)
            {
                foreach (var segmentPair in paragraphUnit.SegmentPairs)
                {
                    if (IsTargetEmpty(segmentPair))
                    {
                        // copy source
                        if (Settings.CopyTargetContent.Value)
                        {
                            Implementation.SourceToTargetCopy.Copy(segmentPair, ItemFactory);
                        }
                        else // generate random text
                        {
                            Implementation.RandomTargetGenerator.Generate(segmentPair, ItemFactory);

                        }
                        SetConformationLevel(segmentPair);
                    }

                    if (!string.IsNullOrEmpty(Settings.AppendStart.Value))
                    {
                        segmentPair.Target.Insert(0,
                        ItemFactory.CreateText(
                        PropertiesFactory.CreateTextProperties(Settings.AppendStart.Value)));
                    }

                    if (!string.IsNullOrEmpty(Settings.AppendEnd.Value))
                    {
                        segmentPair.Target.Insert(segmentPair.Target.Count,
                            ItemFactory.CreateText(
                            PropertiesFactory.CreateTextProperties(Settings.AppendEnd.Value)));
                    }
                }

            }
            base.ProcessParagraphUnit(paragraphUnit);
        }

        private bool IsTargetEmpty(ISegmentPair segmentPair)
        {
            return segmentPair.Target != null && segmentPair.Target.Count == 0;
        }

        private void SetConformationLevel(ISegmentPair segmentPair)
        {
            if (Settings.ToSetDraft)
            {
                segmentPair.Properties.ConfirmationLevel = ConfirmationLevel.Draft;
            }
        }


    }
}
