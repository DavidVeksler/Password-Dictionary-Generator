using System;

namespace PasswordDictionaryGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var list = new DictionaryGenerator().GeneratePassword(maxlength:3);

            //var wordList = new List<string> {"apple", "banana", "rasberry"};

            new PhraseGenerator().GeneratePhrase(maxWords:10, minWords:4, dictionaryFile: @"C:\Users\David Veksler\Desktop\doge_dictionary.txt", fileName: "doge_phrases.txt");

           // Console.Write(list);

            Console.ReadKey();



        }
    }
}
