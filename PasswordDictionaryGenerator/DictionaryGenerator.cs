using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordDictionaryGenerator
{
    public class DictionaryGenerator
    {
        public string GeneratePassword(
            string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ", 
            string prefix = "", 
            int maxlength = 12,
            string fileName = null
            )
        {
            value = new StringBuilder();
            _maxlength = maxlength;
            ValidChars = validChars;

            Dive(prefix, 0);

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                System.IO.File.WriteAllText(fileName,value.ToString());
                return value.Length.ToString() + " chars";
            }
            else
            {
                return value.ToString();
            }

            
        }

        private StringBuilder value = new StringBuilder();
        int _maxlength = 12;
        string ValidChars;


        private void Dive(string prefix, int level)
        {
            level += 1;
            foreach (char c in ValidChars)
            {
                Console.WriteLine(prefix + c);
                value.AppendLine(prefix + c);

                if (level < _maxlength)
                {
                    Dive(prefix + c, level);
                }
            }
        }

    }
}
