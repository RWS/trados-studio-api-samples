using System.Collections.Generic;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.FileTypeSupport.Framework.Core.Utilities.IntegrationApi;

namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleText
{
    class QuickInsertBuilder : AbstractQuickTagBuilder
    {
        public static IList<IQuickTag> BuildStandardQuickTags()
        {
            QuickInsertBuilder builder = new QuickInsertBuilder();
            return builder.CreateStandardQuickTags();
        }

        internal IList<IQuickTag> CreateStandardQuickTags()
        {
            IList<IQuickTag> quickTags = new List<IQuickTag>();

            // assign the default tag pair button for
            // applying bold formatting
            quickTags.Add(CreateDefaultTagPair(QuickTagDefaultId.Bold, "<b>", "</b>", "b"));

            // assign a German quotes text pair to 
            // the first custom QuickInsert button
            quickTags.Add(CreateTextPair("dequot", // command id
                StringResources.DeQuot_Command_Name, // command name
                StringResources.DeQuot_Command_Description, // command description 
                "„", // start string, i.e. opening quote
                "“", // end string, i.e. ending quote
                "", "", "")); // display text, not required for text pairs, therefore left empty
  

            IList<IQuickTag> bidiTags = CreateDefaultBidiQuickTags();

            foreach (IQuickTag tag in bidiTags)
            {
                quickTags.Add(tag);
            }
            return quickTags;
        }
    }
}