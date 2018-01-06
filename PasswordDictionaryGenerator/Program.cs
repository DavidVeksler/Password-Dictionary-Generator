using System;

namespace PasswordDictionaryGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var list = new DictionaryGenerator().GeneratePassword(maxlength:3);

            Console.Write(list);

            Console.ReadKey();



        }
    }
}
