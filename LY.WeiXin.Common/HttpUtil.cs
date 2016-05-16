using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LY.WeiXin.Common
{
    public class HttpUtil
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
            var reqStream = req.GetRequestStream();
            if (!string.IsNullOrEmpty(postData))
            {
                using (var reqStreamWriter = new System.IO.StreamWriter(reqStream))
                {
                    reqStreamWriter.Write(postData);
                }
            }
            var responseStream = req.GetResponse().GetResponseStream();
            
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
