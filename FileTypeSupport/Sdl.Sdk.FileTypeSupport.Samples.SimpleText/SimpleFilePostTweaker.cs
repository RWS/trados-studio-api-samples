using System.IO;
using System.Text;
using Sdl.FileTypeSupport.Framework.NativeApi;
using Sdl.FileTypeSupport.Framework.Core.Utilities.NativeApi;

namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleText
{
    public class SimpleFilePostTweaker : AbstractFilePostTweaker
    {
        protected override void Tweak(INativeOutputFileProperties properties)
        {
            string originalOutputFilePath = properties.OutputFilePath;
            string tweakedOutputFilePath = Path.GetTempFileName();

            // open original output file
            using (StreamReader reader = new StreamReader(originalOutputFilePath))
            {
                // create tweaked output file with byte order mark
                using (StreamWriter writer = new StreamWriter(tweakedOutputFilePath, false, new UTF8Encoding(true)))
                {
                    // copy lines from original output file to tweaked output file
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                    }
                }
            }

            // replace original output file with tweaked output file

            // delete original output file
            File.Delete(originalOutputFilePath);

            // move tweaked output file to original output file path
            File.Move(tweakedOutputFilePath, originalOutputFilePath);
        }
    }
}