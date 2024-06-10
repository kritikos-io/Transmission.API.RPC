#nullable enable
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Transmission.API.RPC.Entity
{
    // Credits to ChatGPT
    /// <summary>
    /// Converts a table (array of arrays) result from torrent-get into TransmissionTorrents in a reasonably performant way
    /// </summary>
    public static class TorrentInfoConverter
    {
        private readonly static Dictionary<string, PropertyInfo> _propertyMap = CreatePropertyMap(typeof(TorrentInfo));

        // Method to create the property map for TorrentInfo
        private static Dictionary<string, PropertyInfo> CreatePropertyMap(Type type)
        {
            return type.GetProperties()
                .Where(prop => prop.GetCustomAttributes(typeof(JsonPropertyAttribute), false).Any())
                .ToDictionary(
                    prop => prop.GetCustomAttributes(typeof(JsonPropertyAttribute), false)
                                .Cast<JsonPropertyAttribute>()
                                .First()
                                .PropertyName!,
                    prop => prop);
        }

        public static TransmissionTorrents ConvertFromJObject(JObject jObject)
        {
            // Extract and convert the "torrents" field
            var torrentsArray = jObject["torrents"] as JArray;
            if (torrentsArray == null || torrentsArray.Count == 0)
            {
                return new TransmissionTorrents
                {
                    Torrents = Array.Empty<TorrentInfo>(),
                    Removed = GetRemoved(jObject)
                };
            }

            var fieldNames = torrentsArray[0].ToObject<string[]>();
            var torrents = new TorrentInfo[torrentsArray.Count - 1];

            for (int i = 1; i < torrentsArray.Count; i++)
            {
                var row = torrentsArray[i].ToObject<object[]>();
                if (fieldNames != null & row != null) torrents[i - 1] = CreateTorrentInfo(fieldNames!, row!);
            }

            return new TransmissionTorrents
            {
                Torrents = torrents,
                Removed = GetRemoved(jObject)
            };
        }

        private static TorrentInfo CreateTorrentInfo(string[] fieldNames, object[] row)
        {
            var torrentInfo = new TorrentInfo();

            for (int j = 0; j < fieldNames.Length; j++)
            {
                var fieldName = fieldNames[j];
                var value = row[j];

                if (_propertyMap.TryGetValue(fieldName, out var property))
                {
                    try
                    {
                        var convertedValue = ConvertValue(value, property.PropertyType);
                        property.SetValue(torrentInfo, convertedValue);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to set property '{property.Name}': {ex.Message}");
                    }
                }
            }

            return torrentInfo;
        }

        private static object? ConvertValue(object value, Type targetType)
        {
            if (value == null)
            {
                return null;
            }

            // Handle specific types directly for efficiency
            if (targetType == typeof(long?)) return value is long l ? (long?)l : null;
            if (targetType == typeof(double?)) return value is double d ? (double?)d : null;
            if (targetType == typeof(bool?)) return value is bool b ? (bool?)b : null;
            if (targetType == typeof(string)) return value?.ToString();

            if (targetType.IsArray)
            {
                var elementType = targetType.GetElementType();
                var valueArray = value as JArray;
                if (valueArray != null)
                {
                    var convertedArray = Array.CreateInstance(elementType, valueArray.Count);

                    for (int i = 0; i < valueArray.Count; i++)
                    {
                        convertedArray.SetValue(ConvertValue(valueArray[i], elementType), i);
                    }
                    return convertedArray;
                }
                else return null;
            }

            // Handle complex nested objects
            if (targetType.IsClass && targetType != typeof(string))
            {
                var nestedJObject = value as JObject;
                if (nestedJObject != null)
                {
                    return nestedJObject.ToObject(targetType);
                }
            }

            return Convert.ChangeType(value, targetType);
        }

        private static long[]? GetRemoved(JObject jObject)
        {
            var removedArray = jObject["removed"] as JArray;
            if (removedArray == null)
            {
                return null;
            }

            return removedArray.ToObject<long[]>();
        }
    }
}
