using Sdl.FileTypeSupport.Framework.Core.Utilities.NativeApi;
using Sdl.FileTypeSupport.Framework.NativeApi;
using System.IO;
using System.Text;

namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleText
{
    #region ClassDeclaration
    public class SimpleFilePreTweaker : AbstractFilePreTweaker
    #endregion
    {
        #region TweakMethodSignature
        protected override void Tweak(IPersistentFileConversionProperties properties)
        #endregion
        {
            #region TweakMethodImplementation
            // open original file
            using (StreamReader reader = new StreamReader(properties.OriginalFilePath))
            {
                // create tweaked file without byte order mark
                using (StreamWriter writer = new StreamWriter(properties.InputFilePath, false, new UTF8Encoding(false)))
                {
                    // copy lines from original file to tweaked file
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            #endregion
        }

        #region WillFileBeTweakedSignature
        protected override bool WillFileBeTweaked(string originalFilePath)
        #endregion
        {
            #region WillFileBeTweakedImplementation
            // if original file has a byte order mark then the original file needs to be tweaked
            return HasByteOrderMark(originalFilePath);
            #endregion
        }

        #region HasByteOrderMarkImplementation
        private bool HasByteOrderMark(string filePath)
        {
            // simple utf-8 byte order mark detection

            // open file
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                // check each byte order mark in UTF8
                foreach (byte byteOrderMark in UTF8Encoding.UTF8.GetPreamble())
                {
                    // if read byte different from byte order mark
                    if (stream.ReadByte() != byteOrderMark)
                    {
                        // file does not have byte order mark
                        return false;
                    }
                }

                // file has byte order mark
                return true;
            }
        }
        #endregion
    }
}