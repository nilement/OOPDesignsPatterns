using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace Objects
{
    public static class Utils
    {
        public static byte[] ObjectToByteArray(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }

        public static string GetInsertQuery(this object obj, string table, bool skipIdField = true, params Tuple<string,object>[] extraColumnsAndValues)
        {
            {
                var insertQuery = $"insert into {table}";
                var columns = "(";
                var values = "(";

                foreach (var field in obj.GetType().GetProperties(BindingFlags.Public |
                                                                  BindingFlags.NonPublic |
                                                                  BindingFlags.Instance |
                                                                  BindingFlags.Static))
                {
                    if (skipIdField && field.Name == "Id")
                        continue;
                    if (field.GetValue(obj) == null)
                        continue;
                    columns += $" {field.Name},";

                    if (field.PropertyType == typeof(string))
                    {
                        values += $" '{field.GetValue(obj)}',";
                    }
                    else
                    {
                        values += $" {field.GetValue(obj)},";
                    }
                }

                foreach (var beb in extraColumnsAndValues)
                {
                    columns += $"{beb.Item1},";
                    if (beb.Item2 is string)
                    {
                        values += $" '{beb.Item2}',";
                    }
                    else
                    {
                        values += $" {beb.Item2},";
                    }
                }

                columns = columns.TrimEnd(',') + ")";
                values = values.TrimEnd(',') + ")";
                return $"{insertQuery} {columns} values {values}";
            }
        }
    }
}