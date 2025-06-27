using Sdl.LanguagePlatform.TranslationMemoryApi.LiteBCM;
using Sdl.LanguagePlatform.TranslationMemoryApi.LiteBCM.Annotations;
using Sdl.LanguagePlatform.TranslationMemoryApi.LiteBCM.Skeleton;
using System.Linq;

namespace Sdl.SDK.LanguagePlatform.Samples.AICompanion
{
    internal static class SegmentExtensions
    {
        public static Segment WithComment(this Segment segment, string comment, FileSkeleton skeleton)
        {
            var commentDefitinitionId = 1;
            while (skeleton.CommentDefinitions.Any(commendDefinition => commendDefinition.Id == commentDefitinitionId))
            {
                commentDefitinitionId++;
            }

            var commentDefinition = new CommentDefinition(commentDefitinitionId)
            {
                Text = comment
            };
            var commentContainer = new CommentContainer(commentDefitinitionId);

            segment.Add(commentContainer);
            skeleton.CommentDefinitions.Add(commentDefinition);
            return segment;
        }

        public static Segment WithText(this Segment segment, string text)
        {
            segment.Add(new TextMarkup { Text = text });
            return segment;
        }

        public static Segment WithRevision(this Segment segment, string text, RevisionType revisionType)
        {
            var revision = new RevisionContainer(revisionType);
            revision.Add(new TextMarkup { Text = text });
            segment.Add(revision);
            return segment;
        }

        public static Segment WithTerm(this Segment segment, string term)
        {
            var termContainer = new TerminologyAnnotationContainer(1);
            termContainer.Add(new TextMarkup { Text = term });
            segment.Add(termContainer);
            return segment;
        }
    }
}
