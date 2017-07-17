using System;
using UnityEngine;
using FullSerializer;

namespace ExtendedLibrary
{
    public static class JsonConverter
    {
        private static fsSerializer serializer = new fsSerializer();

        public static object Deserialize(string json, Type type)
        {
            try
            {
                var data = fsJsonParser.Parse(json);
                object result = null;
                serializer.TryDeserialize(data, type, ref result);

                return result;
            }
            catch
            {
                return JsonUtility.FromJson(json, type);
            }
        }

        public static T Deserialize<T>(string json)
        {
            try
            {
                var data = fsJsonParser.Parse(json);
                T result = default(T);
                serializer.TryDeserialize<T>(data, ref result);

                return result;
            }
            catch
            {
                return JsonUtility.FromJson<T>(json);
            }
        }

        public static string Serialize(object value, Type type)
        {
            try
            {
                fsData result;
                serializer.TrySerialize(type, value, out result);

                return fsJsonPrinter.CompressedJson(result);
            }
            catch
            {
                return JsonUtility.ToJson(value);
            }
        }

        public static string Serialize<T>(T value)
        {
            try
            {
                fsData result;
                serializer.TrySerialize<T>(value, out result);

                return fsJsonPrinter.CompressedJson(result);
            }
            catch
            {
                return JsonUtility.ToJson(value);
            }
        }

        public static string Serialize<T>(object value)
        {
            try
            {
                return Serialize((T) value);
            }
            catch
            {
                return JsonUtility.ToJson(value);
            }
        }

        public static string Serialize(object value)
        {
            try
            {
                return Serialize(value, value.GetType());
            }
            catch
            {
                return JsonUtility.ToJson(value);
            }
        }
    }
}
