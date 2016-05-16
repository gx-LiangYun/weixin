using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LY.WeiXin.Common
{
    public class HttpUtility
    {
        public static string GetHttpGetResultContent(string url)
        {
            HttpWebRequest req = HttpWebRequest.CreateHttp(url);
            req.Method = "GET";
            var responseStream = req.GetResponse().GetResponseStream();
            using (responseStream)
            {
                var streamReader = new System.IO.StreamReader(responseStream);
                string content = streamReader.ReadToEnd();
                streamReader.Dispose();

                return content;
            }
        }

        public static string GetHttpPostResultContent(string url)
        {
            //HttpWebRequest req = HttpWebRequest.CreateHttp(url);
            //req.Method = "POST";
            //var responseStream = req.GetResponse().GetResponseStream();
            //using (responseStream)
            //{
            //    var streamReader = new System.IO.StreamReader(responseStream);
            //    string content = streamReader.ReadToEnd();
            //    streamReader.Dispose();

            //    return content;
            //}
            return GetHttpPostResultContent(url, "");
        }

        public static string GetHttpPostResultContent(string url, string postData)
        {
            HttpWebRequest req = HttpWebRequest.CreateHttp(url);
            req.Method = "POST";
            System.IO.Stream reqStream = null;
            if (!string.IsNullOrEmpty(postData))
            {
                byte[] postBytes = Encoding.UTF8.GetBytes(postData);
                //req.ContentLength = postBytes.Length;
                reqStream = req.GetRequestStream();
                reqStream.Write(postBytes, 0, postBytes.Length);
            }
            var responseStream = req.GetResponse().GetResponseStream();
            if (reqStream != null)
                reqStream.Dispose();

            using (responseStream)
            {
                var streamReader = new System.IO.StreamReader(responseStream);
                string content = streamReader.ReadToEnd();
                streamReader.Dispose();

                return content;
            }
        }
    }
}
