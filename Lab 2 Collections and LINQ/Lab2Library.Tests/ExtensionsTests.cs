using Lab2Library;
using Xunit;

namespace Lab2Library.Tests
{
    public class ExtensionsTests
    {
        [Fact]
        public void ReverseStringTest()
        {
            string str = "hello";
            string reversedSTR = str.ReverseString();
            Assert.Equal("olleh", reversedSTR);
        }

        [Fact]
        public void CharCountTest()
        {
            string str = "ccchc";
            int count = str.CharCount('c');
            Assert.Equal(4, count); 
        }

        [Fact]
        public void CountOccurrencesTest()
        {
            int[] array = { 1, 2, 3, 2, 1, 4, 2 };
            int count = array.CountOccurrences(2);
            Assert.Equal(3, count);
        }

        [Fact]
        public void GetUniqueElementsTest()
        {
            int[] array = { 1, 2, 3, 2, 1, 4, 2 };
            int[] uniqueArray = array.GetUniqueElements();
            Assert.Equal(4, uniqueArray.Length);
        }
    }
}
