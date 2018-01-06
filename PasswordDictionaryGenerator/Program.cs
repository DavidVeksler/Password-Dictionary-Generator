using System;
using System.Collections.Generic;

namespace PasswordDictionaryGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var list = new DictionaryGenerator().GeneratePassword(maxlength:3);

            var wordList = new List<string>();

            wordList.Add("apple");
            wordList.Add("banana");
            wordList.Add("rasberry");
            var list = new PhraseGenerator().GeneratePhrase(wordList: wordList, maxWords:2, dictionaryFile: "dictionary.txt");

           // Console.Write(list);

            Console.ReadKey();



        }
    }
}
