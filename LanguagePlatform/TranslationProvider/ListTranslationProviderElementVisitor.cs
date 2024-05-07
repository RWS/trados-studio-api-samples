using Sdl.LanguagePlatform.Core;

namespace Sdl.Sdk.LanguagePlatform.Samples.ListProvider
{
	internal class ListTranslationProviderElementVisitor : ISegmentElementVisitor
	{
		private readonly ListTranslationOptions _options;
		private string _plainText;

		public string PlainText
		{
			get
			{
				if (_plainText == null)
				{
					_plainText = string.Empty;
				}
				return _plainText;
			}
			set
			{
				_plainText = value;
			}
		}

		public void Reset()
		{
			_plainText = string.Empty;
		}

		public ListTranslationProviderElementVisitor(ListTranslationOptions options)
		{
			_options = options;
		}

		#region ISegmentElementVisitor Members

		public void VisitDateTimeToken(Sdl.LanguagePlatform.Core.Tokenization.DateTimeToken token)
		{
			_plainText += token.Text;
		}

		public void VisitMeasureToken(Sdl.LanguagePlatform.Core.Tokenization.MeasureToken token)
		{
			_plainText += token.Text;
		}

		public void VisitNumberToken(Sdl.LanguagePlatform.Core.Tokenization.NumberToken token)
		{
			_plainText += token.Text;
		}

		public void VisitSimpleToken(Sdl.LanguagePlatform.Core.Tokenization.SimpleToken token)
		{
			_plainText += token.Text;
		}

		public void VisitTag(Tag tag)
		{
			_plainText += tag.TextEquivalent;
		}

		public void VisitTagToken(Sdl.LanguagePlatform.Core.Tokenization.TagToken token)
		{
			_plainText += token.Text;
		}

		public void VisitText(Text text)
		{
			_plainText += text;
		}

		#endregion
	}
}
