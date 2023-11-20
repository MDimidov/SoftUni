using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (var readWord = new StreamReader(wordsFilePath))
            {
                string[] wordsToFind = readWord.ReadToEnd()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                using (var readText = new StreamReader(textFilePath))
                {
                    Dictionary<string, int> wordRepeat = new Dictionary<string, int>();
                    string[] wordsArray = readText.ReadToEnd()
                        .Split(new char[] {' ', ',', '.', '?', '!', '-'}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in wordsToFind)
                    {
                        //int counter = 0;
                        for(int i = 0; i < wordsArray.Length; i++)
                        {
                            if (wordsArray[i].ToLower() == word.ToLower())
                            {
                                if(!wordRepeat.ContainsKey(word))
                                {
                                    wordRepeat.Add(word, 0);
                                }
                                wordRepeat[word]++;
                            }
                        }
                        //Console.WriteLine($"{word} - {counter}");
                        
                        using (StreamWriter output = new StreamWriter(outputFilePath))
                        {
                            foreach(var (currWord, repeated) in wordRepeat.OrderByDescending(x => x.Value))
                            output.WriteLine($"{currWord} - {repeated}");
                        }
                    }
                }
            }
        }
    }
}

