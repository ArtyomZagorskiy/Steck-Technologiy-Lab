using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2Library
{
    public static class Extensions
    {

        //Розширення для класу String
        public static string ReverseString(this string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }


        //Розширення для одновимірних массивів
        public static int CountOccurrences<T>(this T[] array, T value) where T : IEquatable<T>
        {
            int count = 0;
            foreach (T item in array)
            {
                if (item.Equals(value))
                    count++;
            }
            return count;
        }

        public static T[] GetUniqueElements<T>(this T[] array) where T : IEquatable<T>
        {
            return array.Distinct().ToArray();
        }
    }
}
