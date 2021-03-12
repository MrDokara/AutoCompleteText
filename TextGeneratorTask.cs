using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            var sb = new StringBuilder(phraseBeginning);
            int currentCountWords = 0;
            var lastWords = new string[2];
            getLastWords(phraseBeginning, ref lastWords);

            while (currentCountWords < wordsCount)
            {
                if (nextWords.ContainsKey(string.Join(" ", lastWords).Trim()))
                {
                    sb.Append($" {nextWords[string.Join(" ", lastWords).Trim()]}");
                    currentCountWords += getLastWords(nextWords[string.Join(" ", lastWords).Trim()], ref lastWords);
                }
                else if (nextWords.ContainsKey(lastWords[1]))
                {
                    sb.Append($" {nextWords[lastWords[1]]}");
                    getLastWords(nextWords[lastWords[1]], ref lastWords);
                    currentCountWords++;
                }
                else break;
            }

            return sb.ToString();
        }

        private static int getLastWords(string text, ref string[] lastWords)
        {
            int count = 0;
            foreach (Match match in new Regex(@"\w*").Matches(text))
            {
                if (!string.IsNullOrWhiteSpace(match.Value))
                {
                    lastWords[0] = lastWords[1];
                    lastWords[1] = match.Value;
                    count++;
                }
            }
            return count;
        }
    }
}