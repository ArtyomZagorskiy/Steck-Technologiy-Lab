using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2Library;

namespace Lab2
{
    class ExtentionsProgram
    {
        static void Main(string[] args)
        {
            string original = "Hello";
            string reversed = original.ReverseString();
            Console.WriteLine(reversed); // olleH

            string text = "Hello World!";
            int countOfChar = text.CharCount('o');
            Console.WriteLine(countOfChar); // 2

            int[] numbers = { 1, 2, 3, 2, 4, 2 };

            int count = numbers.CountOccurrences(2);
            Console.WriteLine(count); // 3

            int[] uniqueNumbers = numbers.GetUniqueElements();
            Console.WriteLine(string.Join(", ", uniqueNumbers)); // 1, 2, 3, 4
        }
    }
}
