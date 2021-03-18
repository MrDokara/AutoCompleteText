using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            var frequencyDictionary = new Dictionary<string, SortedDictionary<string, int>>();

            foreach (var sentences in text)
            {
                for (int i = 1; i < sentences.Count; i++)
                {
                    var j = i - 1;
                    var currentWord = sentences[i];
                    var previousWord = sentences[j];

                    UpdateDictionary(frequencyDictionary, previousWord, currentWord);
                }

                for (int i = 2; i < sentences.Count; i++)
                {
                    var j = i - 1;
                    var k = j - 1;

                    var currentWord = sentences[i];
                    var previousWord = sentences[j];
                    var prepreviousWord = sentences[k];

                    var twoWords = $"{prepreviousWord} {previousWord}";

                    UpdateDictionary(frequencyDictionary, twoWords, currentWord);
                }
            }

            foreach (var pair in frequencyDictionary)
            {
                var firstWord = pair.Key;
                var secondWord = pair.Value.First().Key;
                result.Add(firstWord, secondWord);
            }

            return result;
        }

        private static void UpdateDictionary(IDictionary<string, SortedDictionary<string, int>> frequencyDictionary, string previousWord, string currentWord)
        {
            if (!frequencyDictionary.ContainsKey(previousWord))
                frequencyDictionary[previousWord] = new SortedDictionary<string, int>();

            if (!frequencyDictionary[previousWord].ContainsKey(currentWord))
                frequencyDictionary[previousWord].Add(currentWord, 0);

            frequencyDictionary[previousWord][currentWord]++;
        }
   }
}