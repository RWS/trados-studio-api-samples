using Sdl.FileTypeSupport.Framework.BilingualApi;
using System.Collections.Generic;
using System.Text;

namespace Sdl.Sdk.FileTypeSupport.Samples.Bil
{
    class BilTextExtractor : IMarkupDataVisitor
    {
        #region "comment list"
        private readonly List<string> _Comments = new List<string>();

        public List<string> GetSegmentComment(ISegment segment)
        {
            _Comments.Clear();
            VisitChildren(segment);
            return _Comments;
        }
        #endregion

        #region "plain text"
        internal StringBuilder PlainText
        {
            get;
            set;
        }

        public string GetPlainText(ISegment segment)
        {
            PlainText = new StringBuilder("");
            VisitChildren(segment);
            return PlainText.ToString();
        }
        #endregion

        // loops through all sub items of the container (IMarkupDataContainer)
        #region "loop"
        private void VisitChildren(IAbstractMarkupDataContainer container)
        {
            foreach (var item in container)
            {
                item.AcceptVisitor(this);
            }
        }
        #endregion

        #region IMarkupDataVisitor Members

        #region "text"
        public void VisitText(IText text)
        {
            PlainText.Append(text.Properties.Text);
        }
        #endregion

        #region "tagpairs"
        public void VisitTagPair(ITagPair tagPair)
        {
            PlainText.Append("<" + tagPair.StartTagProperties.TagContent + ">");
            VisitChildren(tagPair);
            PlainText.Append("</" + tagPair.EndTagProperties.TagContent + ">");
        }
        #endregion

        #region "comments"
        public void VisitCommentMarker(ICommentMarker commentMarker)
        {
            for (int i = 0; i < commentMarker.Comments.Count; i++)
            {
                _Comments.Add(commentMarker.Comments.GetItem(i).Text);
            }
            VisitChildren(commentMarker);
        }
        #endregion

        #region "left empty"
        public void VisitSegment(ISegment segment)
        {
            VisitChildren(segment);
        }

        public void VisitLocationMarker(ILocationMarker location)
        {

        }

        public void VisitLockedContent(ILockedContent lockedContent)
        {

        }

        public void VisitOtherMarker(IOtherMarker marker)
        {

        }

        public void VisitPlaceholderTag(IPlaceholderTag tag)
        {

        }

        public void VisitRevisionMarker(IRevisionMarker revisionMarker)
        {

        }
        #endregion

        #endregion
    }
}
