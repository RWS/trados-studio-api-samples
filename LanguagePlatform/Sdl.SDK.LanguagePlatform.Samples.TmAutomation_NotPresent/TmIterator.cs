

namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
    using System.Linq;
    using System.Windows.Forms;
    using Sdl.LanguagePlatform.TranslationMemory;
    using Sdl.LanguagePlatform.TranslationMemoryApi;

    public class TMIterator
    {
        public void Iterate(string tmPath)
        {
            #region "open"
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);
            #endregion

            #region "iterator"
            RegularIterator tmIterator = new RegularIterator(1);
            #endregion

            #region "GetTUs"
            TranslationUnit[] Tus = tm.LanguageDirection.GetTranslationUnits(ref tmIterator);
            #endregion

            #region "loop"
            #region "while"
            while (Tus.Count<TranslationUnit>() > 0)
            #endregion
            {
                #region "LoopTus"
                foreach (TranslationUnit Tu in Tus)
                #endregion
                {
                    #region "LoopValues"
                    foreach (FieldValue item in Tu.FieldValues)
                    #endregion
                    {
                        #region "DetermineFieldName"
                        if (item.Name == "Customer")
                        #endregion
                        {
                            #region "DetermineFieldValue"
                            if (item.ToString() == "Microsoft")
                            {
                                MessageBox.Show(Tu.SourceSegment.ToPlain());
                            }
                            #endregion
                        }
                    }
                }
                #region "update"
                Tus = tm.LanguageDirection.GetTranslationUnits(ref tmIterator);
                #endregion
            }
            #endregion
        }
    }
}
