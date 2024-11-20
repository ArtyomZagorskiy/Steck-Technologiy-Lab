using Lab2Library;
using Xunit;

namespace Lab2Library.Tests
{
    public class ExtendedDistionaryTests
    {
        [Fact]
        public void AddTest()
        {
            ExtendedDictionary<int, string, string> dictionary = new ExtendedDictionary<int, string, string>();
            dictionary.Add(1, "B", "A");
            Assert.NotEmpty(dictionary);
        }

        [Fact]
        public void RemoveTest()
        {
            ExtendedDictionary<int, string, string> dictionary = new ExtendedDictionary<int, string, string>();
            dictionary.Add(1, "B", "A");
            dictionary.Remove(1);
            Assert.Empty(dictionary);
        }

        [Fact]
        public void IndexTest()
        {
            ExtendedDictionary<int, string, string> dictionary = new ExtendedDictionary<int, string, string>();
            dictionary.Add(1, "B", "A");
            dictionary.Add(2, "C", "D");
            Assert.Equal("C", dictionary[2].Value1);
        }

        [Fact]
        public void IsKeyAndValueExistTest()
        {
            ExtendedDictionary<int, string, string> dictionary = new ExtendedDictionary<int, string, string>();
            dictionary.Add(10, "B", "A");
            Assert.True(dictionary.IsKeyExist(10));
            Assert.True(dictionary.IsValueExist("B", "A"));
        }
    }
}
