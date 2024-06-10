using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transmission.API.RPC.Common
{
	/// <summary>
	/// Transmission response 
	/// </summary>
	public class TransmissionResponse
	{
		/// <summary>
		/// Contains "success" on success, or an error string on failure.
		/// </summary>
        public string Result { get; }

        /// <summary>
        /// Uniquely identifies which request this is a response to
        /// </summary>
        public int? Tag { get; }

        /// <summary>
        /// Data
        /// </summary>
        public JObject Arguments { get; }

        public TransmissionResponse(string json)
        {
            using var stringReader = new StringReader(json);
            using var jsonReader = new JsonTextReader(stringReader);

            while (jsonReader.Read())
            {
                if (jsonReader.TokenType == JsonToken.PropertyName)
                {
                    if (jsonReader.Value.ToString() == "result")
                    {
                        jsonReader.Read();
                        Result = jsonReader.Value.ToString();
                    }

                    else if (jsonReader.Value.ToString() == "tag")
                    {
                        jsonReader.Read();
                        Tag = jsonReader.Value != null ? (int?)Convert.ToInt32(jsonReader.Value) : null;
                    }

                    else if (jsonReader.Value.ToString() == "arguments")
                    {
                        jsonReader.Read();
                        Arguments = JObject.Load(jsonReader);
                    }
                }
            }
        }
    }
}
