using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader firstFile = new StreamReader(firstInputFilePath))
            {
                using (StreamReader secondFile = new StreamReader(secondInputFilePath))
                {
                    using (StreamWriter output = new StreamWriter(outputFilePath))
                    {
                        string oddLine = firstFile.ReadLine();
                        string evenLine = secondFile.ReadLine();
                        while ((oddLine) != null
                            || (evenLine) != null)
                        {
                            if (oddLine != null)
                            {
                                output.WriteLine(oddLine);
                            }
                            if (evenLine != null)
                            {
                                output.WriteLine(evenLine);
                            }
                            oddLine = firstFile.ReadLine();
                            evenLine = secondFile.ReadLine();
                        }
                    }
                }
            }
        }
    }
}

