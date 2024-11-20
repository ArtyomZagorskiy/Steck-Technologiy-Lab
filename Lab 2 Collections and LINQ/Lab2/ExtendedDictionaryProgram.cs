using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2Library;

namespace Lab2
{
    class ExtendedDictionaryProgram
    {
        static void main(string[] args)
        {
            ExtendedDictionary<int, string, string> dictionary = new ExtendedDictionary<int, string, string>();


            dictionary.Add(1, "Bob", "Anderson");
            dictionary.Add(2, "John", "Smith");

            var element = dictionary[1];
            Console.WriteLine($"Key: {element.Key}, Value1: {element.Value1}, Value2: {element.Value2}");

            Console.WriteLine(dictionary.IsKeyExist(2)); // True
            Console.WriteLine(dictionary.IsValueExist("Bob", "Anderson")); // True

            dictionary.Remove(1);
            Console.WriteLine(dictionary.Count); // 1

            foreach (var elem in dictionary)
            {
                Console.WriteLine($"Key: {elem.Key}, Value1: {elem.Value1}, Value2: {elem.Value2}");
            }
        }
    }
}
