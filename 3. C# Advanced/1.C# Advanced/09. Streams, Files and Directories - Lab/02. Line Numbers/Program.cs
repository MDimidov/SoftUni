using System;
using System.Collections.Generic;
using System.Linq;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using(var reader = new StreamReader(inputFilePath))
            {
                string line;
                int counter = 1;
                using(var writer = new StreamWriter(outputFilePath))
                {
                    while((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"{counter++}. {line}");
                    }
                }
            }
        }
    }
}

