using Newtonsoft.Json;
using System.Collections.Generic;

namespace ACC.Convert
{
    /// <summary>
    /// json转换
    /// </summary>
    public static class Json
    {
        /// <summary>
        /// 实体转json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        /// <summary>
        /// 字符串转实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToObj<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 字符串转实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this string json)
        {
            return json == null ? default(List<T>) : JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}
