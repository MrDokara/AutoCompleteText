using System.Collections.Generic;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            string[] sentences = text.Split('.', '!', ';', ':', '(', ')');
            for(int i=0;i<sentences.Length;i++)
            {
                string []words = sentences[i].Split(',', ' ');
                var wordslist = new List<string>();
                for(int j =0;j<words.Length;j++)
                {
                    wordslist.Add(words[j]);
                }
                sentencesList.Add(wordslist);
            }
            return sentencesList;
        }
    }
}