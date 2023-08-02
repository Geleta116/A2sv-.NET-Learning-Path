using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequencyNamespace
{
    public class WordFrequencyCounter
    {
        public Dictionary<string, int> CountFrequency(string phrase)
        {
            string[] separatedWords = phrase.Split(' ');
            Dictionary<string, int> counter = new Dictionary<string, int>();

            foreach (string word in separatedWords)
            {
                string cleanedWord = Regex.Replace(word, @"\W", "").ToUpper();

                if (counter.ContainsKey(cleanedWord))
                {
                    counter[cleanedWord]++;
                }
                else
                {
                    counter[cleanedWord] = 1;
                }
            }

            return counter;
        }
    }
}
