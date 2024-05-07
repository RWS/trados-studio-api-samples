﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.FileTypeSupport.Framework.Core.Utilities.NativeApi;

namespace Sdl.SDK.BatchTasks.Samples.PseudoTranslation.Implementation
{
	internal class RandomTargetGenerator : IMarkupDataVisitor
	{
		private List<IAbstractMarkupData> nodesToDelete;
		private readonly RevisionType revisionTypeToIgnore;

		private static readonly Random random = new Random((int)DateTime.Now.Ticks);


		public static void Generate(ISegmentPair segmentPair, IDocumentItemFactory itemFactory)
		{
			var collector = new RandomTargetGenerator();
			ISegment segment = collector.GenerateRandomTarget(segmentPair.Source);
			segmentPair.Target.Clear();
			segment.MoveAllItemsTo(segmentPair.Target);
			segmentPair.Properties.TranslationOrigin = itemFactory.CreateTranslationOrigin();
			segmentPair.Properties.TranslationOrigin.OriginType = DefaultTranslationOrigin.Source;
		}

		/// <summary>
		/// Default constructor 
		/// </summary>
		public RandomTargetGenerator()
		{
			revisionTypeToIgnore = RevisionType.Delete;
		}

		public RandomTargetGenerator(RevisionType revisionTypeToIgnore)
		{
			this.revisionTypeToIgnore = revisionTypeToIgnore;
		}

		public ISegment GenerateRandomTarget(ISegment sourceSegment)
		{
			ISegment targetSegment = (ISegment)sourceSegment.Clone();
			nodesToDelete = new List<IAbstractMarkupData>();
			targetSegment.AcceptVisitor(this);
			nodesToDelete.ForEach(n => DeleteNode(n));

			return targetSegment;
		}

		private void DeleteNode(IAbstractMarkupData node)
		{
			//Remove node from tree 
			int index = node.IndexInParent;
			IAbstractMarkupDataContainer parent = node.Parent;
			node.RemoveFromParent();

			//If this is a deleted revision marker then no more processing is required 
			IRevisionMarker revisionMarker = node as IRevisionMarker;
			if (revisionMarker != null)
			{
				if (revisionMarker.Properties.RevisionType == revisionTypeToIgnore)
				{
					return;
				}
			}

			//If a comment or inserted revision then copy children to parent at the index location of the original node we have removed
			IAbstractMarkupDataContainer container = node as IAbstractMarkupDataContainer;
			if (container.Count() > 0)
			{
				container.MoveItemsTo(parent, index, 0, container.Count());
			}
		}

		/// <summary>
		/// Visit the children of this container
		/// </summary>
		/// <param name="container"></param>
		public void VisitChildren(IAbstractMarkupDataContainer container)
		{
			foreach (var item in container)
			{
				item.AcceptVisitor(this);
			}
		}

		#region IMarkupDataVisitor Members

		/// <summary>
		///     All comment markers are marked to be deleted. The children of the comment will be 
		///     copied to the parent so still need processing
		/// </summary>
		/// <param name="commentMarker"></param>
		public void VisitCommentMarker(ICommentMarker commentMarker)
		{
			nodesToDelete.Add(commentMarker);
			VisitChildren(commentMarker);
		}

		/// <summary>
		///     No processing required on this item
		/// </summary>
		/// <param name="location"></param>
		public void VisitLocationMarker(ILocationMarker location)
		{
		}

		/// <summary>
		///     No processing required on this item
		/// </summary>
		/// <param name="lockedContent"></param>
		public void VisitLockedContent(ILockedContent lockedContent)
		{
		}

		/// <summary>
		///     No processing required on this item but should process children
		/// </summary>
		/// <param name="marker"></param>
		public void VisitOtherMarker(IOtherMarker marker)
		{
			VisitChildren(marker);
		}

		/// <summary>
		///     No processing required on this item
		/// </summary>
		/// <param name="tag"></param>
		public void VisitPlaceholderTag(IPlaceholderTag tag)
		{
		}

		/// <summary>
		///   All revisions are marker to be deleted but we must visit the children of non-deleted revision markers 
		///   in case the revisions contains further comment nodes that need removing. 
		/// </summary>
		/// <param name="revisionMarker"></param>
		public void VisitRevisionMarker(IRevisionMarker revisionMarker)
		{
			nodesToDelete.Add(revisionMarker);
			if (revisionMarker.Properties.RevisionType != revisionTypeToIgnore)
			{
				VisitChildren(revisionMarker);
			}
		}

		/// <summary>
		///     No processing required on this item but should process children
		/// </summary>
		/// <param name="segment"></param>
		public void VisitSegment(ISegment segment)
		{
			VisitChildren(segment);
		}

		/// <summary>
		///     No processing required on this item but should process children
		/// </summary>
		/// <param name="tagPair"></param>
		public void VisitTagPair(ITagPair tagPair)
		{
			VisitChildren(tagPair);
		}

		/// <summary>
		///     No processing required on this item
		/// </summary>
		/// <param name="text"></param>
		public void VisitText(IText text)
		{
			text.Properties.Text = GenerateRandomText(text.Properties.Text);
		}

		#endregion

		private const string charList = "abcdefghijklmnopqrstuvwxyz";
		private string GenerateRandomText(string text)
		{
			var sb = new StringBuilder(text.Length);
			for (int i = 0; i < text.Length; i++)
			{
				if (char.IsPunctuation(text[i]) || char.IsSeparator(text[i]))
				{
					sb.Append(text[i]);
				}
				else
				{
					char c = charList[random.Next(0, 26)];
					sb.Append(c);
				}
			}
			return sb.ToString();
		}
	}
}
