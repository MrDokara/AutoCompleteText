using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            string[] sentences = text.Split('.', '!', ';', ':', '(', ')', '?');
 
                for (int i = 0; i < sentences.Length; i++)
                {
                    string[] words = sentences[i].Split(',', ' ', '^', '#', '$', '-', '+', '1', '=', ' ', '\t', '\n', '\r');
                    var wordslist = new List<string>();
                    if (sentences[i] != "")
                    {
                        for (int j = 0; j < words.Length; j++)
                        {
                            if (words[j] != "")
                            {
                                if (char.IsUpper(words[j][0]) == true)
                                {
                                    StringBuilder sb = new StringBuilder(words[j]);
                                    sb[0] = char.ToLower(words[j][0]);
                                    wordslist.Add(sb.ToString());
                                }
                                else
                                    wordslist.Add(words[j]);
                            }
                        }
                        sentencesList.Add(wordslist);
                    }
                }
            return sentencesList;
        }
    }
}