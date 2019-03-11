using System.Collections.Generic;

namespace Reflections
{
    internal static class DictionaryExtensions
    {
        public static bool DoesNotContainKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.ContainsKey(key) == false;
        }
    }
}