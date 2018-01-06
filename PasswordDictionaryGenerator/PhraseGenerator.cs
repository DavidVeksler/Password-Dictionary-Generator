using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordDictionaryGenerator
{
    public class PhraseGenerator
    {
        private StringBuilder value = new StringBuilder();
        private int _minWords = 0;
        private int _maxWords = 12;

        List<string> _wordList;

        public string GeneratePhrase(List<string> wordList, int minWords = 0, int maxWords = 12, string fileName = null, string dictionaryFile = null)
        {
            value = new StringBuilder();
            _minWords = minWords;
            _maxWords = maxWords;
            _wordList = wordList;

            if (!string.IsNullOrWhiteSpace(dictionaryFile))
            {
                _wordList = System.IO.File.ReadAllLines(dictionaryFile).ToList();
            }


            Dive("", minWords);

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                System.IO.File.WriteAllText(fileName, value.ToString());
                return value.Length.ToString() + " chars";
            }
            else
            {
                return value.ToString();
            }
        }

        private void Dive(string prefix, int level)
        {
            level += 1;
            foreach (string word in _wordList)
            {
                Console.WriteLine(prefix + " " + word);
                value.AppendLine(prefix + " " + word);

                if (level < _maxWords)
                {
                    Dive(prefix + " " + word, level);
                }
            }
        }

    }
}
