using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentences = new List<List<string>>();
            foreach (Match sentence in new Regex(@"([a-zA-Z']+|[^.!?;:()]?)+([^.!?;:()]|$)").Matches(text))
            {
                if (!string.IsNullOrEmpty(sentence.Value))
                {
                    sentences.Add(new List<string>());
                    foreach (Match word in new Regex(@"[a-zA-Z']+").Matches(sentence.Value))
                    {
                        if (!string.IsNullOrEmpty(word.Value))
                            sentences[sentences.Count - 1].Add(word.Value.ToLower());
                    }
                }
            }
            return sentences;
        }
    }
}