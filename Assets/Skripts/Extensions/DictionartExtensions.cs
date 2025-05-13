using System.Collections.Generic;

namespace Skripts.Extensions
{
    public static class DictionartExtensions
    {
        public static TValue GetOrCreate<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
            where TValue : new()
        {
            if (!dict.ContainsKey(key))
            {
                dict[key] = new();
            }

            return dict[key];
        }
    
    public static bool IsNullOrEmpty<TKey, TValue>(this Dictionary<TKey, TValue> dict)
    {
        return dict == null || dict.Count == 0;
    }
    
    }
}