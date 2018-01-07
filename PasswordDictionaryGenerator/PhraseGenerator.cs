using System;
using System.IO;
using System.Linq;
using System.Text;

namespace PasswordDictionaryGenerator
{
    public class PhraseGenerator
    {
        private int _maxWords = 10;
        private string[] _wordList;
        private StringBuilder _phraseStringBuilder = new StringBuilder(2000000000);
        private string _fileName;

        public string GeneratePhrase(string[] wordList = null, int minWords = 0, int maxWords = 10,
            string fileName = null, string dictionaryFile = null)
        {
            _phraseStringBuilder = new StringBuilder();
            _maxWords = maxWords;
            _wordList = wordList;
            _fileName = fileName;

            if (!string.IsNullOrWhiteSpace(dictionaryFile))
                _wordList = File.ReadAllLines(dictionaryFile).Distinct().Where(s => s != string.Empty).ToArray();
            Dive("", minWords);

            if (string.IsNullOrWhiteSpace(fileName)) return _phraseStringBuilder.ToString();

            PersistToFile();

            Console.WriteLine("Done");

            return _phraseStringBuilder.Length + " chars";
        }

        private void Dive(string prefix, int level)
        {
            if (_phraseStringBuilder.Length > 2000000000)
            {
                PersistToFile();
            }

            level += 1;
            //Console.Write($"lvl {level} ");

            if (DateTime.Now.Millisecond == 0)
            {
                //Console.WriteLine(prefix + " " + levle);
                Console.WriteLine($"lvl {level} ");
            }

            foreach (var word in _wordList)
            {
                string phrase = $"{prefix} {word}";

                // hack: assume less than 3 usages of a word in a phrase:

                if (!prefix.Contains(word))
                {
                    if (DateTime.Now.Millisecond== 0)
                    {
                        Console.WriteLine(phrase);
                    }

                    _phraseStringBuilder.AppendLine(phrase);
                }

                if (level < _maxWords)
                    Dive(phrase, level);
            }
        }

        private int countSubStrings(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle)) return 0;

            int needleCount = (haystack.Length - haystack.Replace(needle, "").Length) / needle.Length;
            return needleCount;
        }

        public const int ChunkStringLength = 1000000;

        private void PersistToFile()
        {
            Console.WriteLine("writing to file " + new FileInfo(_fileName).FullName);
            using (StreamWriter sw = new StreamWriter(_fileName, true))
            {
                while (_phraseStringBuilder.Length > ChunkStringLength)
                {
                    sw.Write(_phraseStringBuilder.ToString(0, ChunkStringLength));
                    _phraseStringBuilder.Remove(0, ChunkStringLength);
                }
                sw.Write(_phraseStringBuilder);
            }
            //File.WriteAllText(_fileName, _phraseStringBuilder.ToString());
            _phraseStringBuilder.Clear();
            _phraseStringBuilder = null;
            _phraseStringBuilder = new StringBuilder(2000000000);



        }
    }
}