using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            var frequencyDictionary = new Dictionary<string, Dictionary<string, int>>();

            foreach (var sentences in text)
            {
                for (int current = 1; current < sentences.Count; current++)
                {
                    var previous = current - 1;

                    if (!frequencyDictionary.ContainsKey(sentences[previous]))
                        frequencyDictionary[sentences[previous]] = new Dictionary<string, int>();

                    if (!frequencyDictionary[sentences[previous]].ContainsKey(sentences[current]))
                        frequencyDictionary[sentences[previous]].Add(sentences[current], 0);

                    frequencyDictionary[sentences[previous]][sentences[current]]++;
                }

                for (int current = 2; current < sentences.Count; current++)
                {
                    var previous = current - 1;
                    var preprevious = previous - 1;


                }
            }

            return result;
        }
   }
}