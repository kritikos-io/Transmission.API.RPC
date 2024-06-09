using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDRemote.Backends.Transmission
{
    /// <summary>
    /// JSON type converter for type long[] or long or int[] or int
    /// This is needed because the Availability field was introduced in Transmission 4.0.0
    /// On earlier versions, the field defaults to "0" and decoding to an array fails.
    /// </summary>
    public class IntOrArrayConverter : JsonConverter
    {
        /// <summary>
        /// Returns true whether the object is of type long[] or long or int[] or int
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(long[]) || objectType == typeof(long) || objectType == typeof(int[]) || objectType == typeof(int) || objectType == typeof(long?[]) || objectType == typeof(long?) || objectType == typeof(int?[]) || objectType == typeof(int?);
        }

        /// <summary>
        /// Read long[] or single long (not array) from json
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        /// <exception cref="JsonSerializationException"></exception>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            if (token.Type == JTokenType.Integer)
            {
                // Return an array with one element if it's a single integer
                if (objectType == typeof(long[])) return new long[] { (long)token };
                if (objectType == typeof(long?[])) return new long?[] { (long?)token };
            }
            else if (token.Type == JTokenType.Array)
            {
                // Return the integer array if it's a JSON array
                if (objectType == typeof(long[])) return token.ToObject<long[]>();
                if (objectType == typeof(long?[])) return token.ToObject<long?[]>();
            }

            throw new JsonSerializationException("Unexpected token type");
        }

        /// <summary>
        /// Write long[] to json
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
            {
                long?[] longArray = (long?[])value;
                if (longArray.Length == 1)
                {
                    writer.WriteValue(longArray[0]);
                }
                else
                {
                    JArray array = new JArray(longArray);
                    array.WriteTo(writer);
                }
            }
        }
    }
}
