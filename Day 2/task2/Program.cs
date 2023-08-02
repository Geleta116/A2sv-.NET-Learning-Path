using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequencyNamespace
{
    public class WordFrequencyCounter
    {
        public static Dictionary<string, int> CountFrequency(string phrase)
        {   
            phrase = phrase.Trim();
            string[] separatedWords = phrase.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> counter = new Dictionary<string, int>();

            foreach (string word in separatedWords)
            {
                string cleanedWord = Regex.Replace(word, @"[^a-zA-Z0-9]", "").ToUpper();
                if(cleanedWord != ""){
                    if (counter.ContainsKey(cleanedWord))
                    {
                        counter[cleanedWord]++;
                    }
                    else
                    {
                        counter[cleanedWord] = 1;
                    }
                }
            }

            return counter;
        }

        static void Main(string[] args)
        {
            Dictionary<string, int> counts = CountFrequency("Hello Hello Hello 234  c  ; ??? sdf    ");
            foreach (KeyValuePair<string, int> item in counts)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }
    }
}
