using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ACC.Convert;
using ACC.SDK.Baidu;

namespace ACC.Common
{
    /// <summary>
    /// HttpClient
    /// </summary>
    public static class HttpClientHelper
    {
        #region HttpGet
        /// <summary>
        /// 使用Get方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static async Task<string> HttpGetAsync(string url, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            //HttpUtility.UrlEncode 编码HttpUtility.UrlDecode 解码
            HttpClient httpClient = new HttpClient();
            var data = await httpClient.GetByteArrayAsync(url);
            var ret = encoding.GetString(data);
            return ret;
        }
        /// <summary>
        /// Http Get 同步方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HttpGet(string url, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            url = System.Web.HttpUtility.UrlEncode(url, encoding);
            HttpClient httpClient = new HttpClient();
            var t = httpClient.GetByteArrayAsync(url);
            t.Wait();
            var ret = encoding.GetString(t.Result);
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static T HttpGetJson<T>(string url, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            HttpClient httpClient = new HttpClient();
            var t = httpClient.GetByteArrayAsync(url);
            t.Wait();
            var ret = encoding.GetString(t.Result);
            return ret.ToObj<T>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static ErrModel HttpGetData(string url, Encoding encoding = null)
        {
            ErrModel model = new ErrModel();
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            HttpClient httpClient = new HttpClient();
            var t=httpClient.GetAsync(url);
            t.Wait();
            var type=t.Result.Content.Headers.ContentType.MediaType;
            if(type.ToLower() == "application/json")
            {

            }
            var stram = t.Result.Content.ReadAsStreamAsync();
            stram.Wait();
            model.Data = StreamToBytes(stram.Result);
            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[] StreamToBytes(Stream input)
        {
            byte[] array = new byte[16384];
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                int count;
                while ((count = input.Read(array, 0, array.Length)) > 0)
                {
                    memoryStream.Write(array, 0, count);
                }
                result = memoryStream.ToArray();
            }
            return result;
        }
        #endregion


        ///<summary>
        /// 通过NetworkInterface读取网卡Mac
        ///</summary>
        ///<returns></returns>
        public static string GetMacByNetworkInterface()
        {
            try
            {
                string sp = string.Empty;
                List<string> macs = new List<string>();
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface ni in interfaces)
                {
                    macs.Add(ni.GetPhysicalAddress().ToString());
                    sp += ni.GetPhysicalAddress().ToString();
                }
                return sp;
            }
            catch (Exception)
            {

                return "wxmacs";
            }
        }
    }
}
