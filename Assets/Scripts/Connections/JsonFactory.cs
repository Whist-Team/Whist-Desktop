using System.Collections.Generic;
using System.Linq;

namespace Connections
{
    public static class JsonFactory
    {
        public static string FromDictionary(Dictionary<string, string> dictionary)
        {
            IEnumerable<string> entries = dictionary.Select(x => $"\"{x.Key}\":\"{x.Value}\"");
            return "{" + string.Join(",", entries) + "}";
        }
    }
}