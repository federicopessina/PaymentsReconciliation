﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Xml.Serialization;

namespace PaymentsReconciliation.Model
{
    public static class DataSerializer
    {
        public static void JsonSerialize(object data, string filePath)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            StreamWriter sw = new StreamWriter(filePath);
            JsonWriter jsonWriter = new JsonTextWriter(sw);

            jsonSerializer.Serialize(jsonWriter, data);

            sw.Close();

        }

        public static object JsonDeserialize(Type dataType, string filePath)
        {

            JObject obj = null;
            JsonSerializer jsonSerializer = new JsonSerializer();

            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                JsonReader jsonReader = new JsonTextReader(sr);

                obj = jsonSerializer.Deserialize(jsonReader) as JObject;
                
                jsonReader.Close();
                sr.Close();
            }

            return obj.ToObject(dataType);
        }
    }
}
