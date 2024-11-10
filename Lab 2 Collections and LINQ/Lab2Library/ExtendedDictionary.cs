using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Library
{
    public class ExtendedDictionary<T, U, V> : IEnumerable<ExtendedDictionaryElement<T, U, V>>
    {
        private List<ExtendedDictionaryElement<T, U, V>> elements = new List<ExtendedDictionaryElement<T, U, V>>();
        public int Count => elements.Count;

        public void Add(T key, U value1, V value2)
        {
            if (IsKeyExist(key))
                throw new ArgumentException("An element with this key already exists.");

            elements.Add(new ExtendedDictionaryElement<T, U, V>(key, value1, value2));
        }

        public bool IsKeyExist(T key)
        {
            return elements.Any(e => EqualityComparer<T>.Default.Equals(e.Key, key));
        }

        public bool Remove(T key)
        {
            var element = elements.FirstOrDefault(e => EqualityComparer<T>.Default.Equals(e.Key, key));
            if (element != null)
            {
                elements.Remove(element);
                return true;
            }
            return false;
        }

        public bool IsValueExist(U value1, V value2)
        {
            return elements.Any(e => EqualityComparer<U>.Default.Equals(e.Value1, value1) && EqualityComparer<V>.Default.Equals(e.Value2, value2));
        }

        public ExtendedDictionaryElement<T, U, V> this [T key]
        {
            get
            {
                var element = elements.FirstOrDefault(e => EqualityComparer<T>.Default.Equals(e.Key, key));
                if (element == null)
                    throw new KeyNotFoundException("An element with the specified key was not found.");
                return element;
            }
        }

        public IEnumerator<ExtendedDictionaryElement<T, U, V>> GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    public class ExtendedDictionaryElement<T, U, V>
    {
        public T Key { get; }
        public U Value1 { get; }
        public V Value2 { get; }

        public ExtendedDictionaryElement(T key, U value1, V value2)
        {
            Key = key;
            Value1 = value1;
            Value2 = value2;
        }
    }
}
