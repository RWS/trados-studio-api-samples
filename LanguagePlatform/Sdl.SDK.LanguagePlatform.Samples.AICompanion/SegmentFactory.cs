using Sdl.LanguagePlatform.TranslationMemoryApi.AICompanion.Model;
using Sdl.LanguagePlatform.TranslationMemoryApi.LiteBCM;
using Sdl.LanguagePlatform.TranslationMemoryApi.LiteBCM.Common;
using Sdl.LanguagePlatform.TranslationMemoryApi.LiteBCM.Skeleton;
using System;
using System.Collections.Generic;

namespace Sdl.SDK.LanguagePlatform.Samples.AICompanion
{
    internal static class SegmentFactory
    {
        public static List<Segment> CreateSegments(AISearchParams aISearchParams, Segment sourceSegment, FileSkeleton fileSkeleton)
        {
            var segments = new List<Segment>();
            switch (aISearchParams.Prompt.Name)
            {
                case "Comments":
                    segments.Add(CreateSegmentWithComment(sourceSegment, fileSkeleton));
                    break;
                case "Revisions":
                    segments.Add(CreateSegmentWithRevisions(sourceSegment));
                    break;
                case "Terminology":
                    segments.Add(CreateSegmentWithTerm(sourceSegment));
                    break;
                default:
                    segments.Add(CreateSegmentWithComment(sourceSegment, fileSkeleton));
                    segments.Add(CreateSegmentWithRevisions(sourceSegment));
                    segments.Add(CreateSegmentWithTerm(sourceSegment));
                    break;
            }

            return segments;
        }

        private static Segment CreateSegmentWithComment(Segment sourceSegment, FileSkeleton fileSkeleton)
        {
            return GetResultSegmentWithChildren(sourceSegment)
                .WithComment("Translation with comment.", fileSkeleton);
        }

        private static Segment CreateSegmentWithRevisions(Segment sourceSegment)
        {
            return GetResultSegmentWithChildren(sourceSegment)
                .WithText(" - ")
                .WithRevision("without", RevisionType.Deleted)
                .WithRevision("with", RevisionType.Inserted)
                .WithText(" revision.");
        }

        private static Segment CreateSegmentWithTerm(Segment sourceSegment)
        {
            return GetResultSegmentWithChildren(sourceSegment)
                .WithText(" - with ")
                .WithTerm("terminology")
                .WithText(".");
        }

        private static Segment GetResultSegmentWithChildren(Segment sourceSegment)
        {
            var resultSegment = new Segment(sourceSegment.SegmentNumber)
            {
                TranslationOrigin = new TranslationOrigin(DefaultTranslationOrigin.NeuralMachineTranslation)
                {
                    CreatedBy = "Sample AI Companion User",
                    CreatedOn = DateTime.Now,
                    MatchPercent = 0,
                    OriginSystem = "Sample AI Companion"
                }
            };
            resultSegment.Add(sourceSegment.Children);
            return resultSegment;
        }
    }
}