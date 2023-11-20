using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        public static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            using (reader)
            {
                int counter = 0;
                string line = reader.ReadLine();
                using (var writer = new StreamWriter(outputFilePath))
                {
                    while (line != null)
                    {
                        if (counter % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }
                        line = reader.ReadLine();
                        counter++;
                    }
                }
            }
        }
    }
}
