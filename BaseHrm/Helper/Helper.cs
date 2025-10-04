using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BaseHrm
{
    public static class Helper
    {
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true, // in đẹp, có indent
            Converters = { new JsonStringEnumConverter() }, // enum -> string
            ReferenceHandler = ReferenceHandler.IgnoreCycles // tránh vòng lặp navigation EF
        };

        /// <summary>
        /// Serialize bất kỳ object nào sang JSON string.
        /// </summary>
        public static string ToJson(object obj)
        {
            if (obj == null) return "null";
            return JsonSerializer.Serialize(obj, _jsonOptions);
        }

        /// <summary>
        /// In object ra Console dưới dạng JSON.
        /// </summary>
        public static void PrintJson(object obj)
        {
            Console.WriteLine(ToJson(obj));
        }
    }
}
