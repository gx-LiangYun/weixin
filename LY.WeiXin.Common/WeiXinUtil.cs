using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace LY.WeiXin.Common
{
    /// <summary>
    /// 微信辅助工具类 
    /// </summary>
    public class WeiXinUtil
    {
        private static readonly object syncLock = new object();

        /// <summary>
        /// 验证微信签名 
        /// </summary>
        /// <param name="signature">微信签名 </param>
        /// <param name="echostr">验证通过后，将 echostr 返回给微信服务器</param>
        /// <param name="timestamp">微信传过来的时间戮</param>
        /// <param name="nonce">微信传过来的随机数</param>
        /// <param name="wx_token">开发者在微信服务器上填写的 Token </param>
        /// <returns></returns>
        public static bool CheckSignature(string signature, string echostr, string timestamp, string nonce, string wx_token)
        {
            if (string.IsNullOrEmpty(signature) || string.IsNullOrEmpty(echostr)
                || string.IsNullOrEmpty(timestamp) || string.IsNullOrEmpty(nonce))
            {
                throw new Exception("微信服务器签名参数不全！");
            }
            if (string.IsNullOrEmpty(wx_token))
            {
                throw new Exception("Token 参数不正确！");
            }
            string[] paramsArr = new string[] { wx_token, timestamp, nonce };
            Array.Sort<string>(paramsArr);
            string tmpStr = string.Join("", paramsArr);
            byte[] sha1Data = SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(tmpStr));
            string sha1String = BitConverter.ToString(sha1Data).Replace("-", "");
            return string.Equals(signature, sha1String, StringComparison.OrdinalIgnoreCase);
        }

        public static string GetAccessToken(string wx_appid, string wx_secret)
        {
            WeiXinModels.AccessTokenModel accessToken = (WeiXinModels.AccessTokenModel)
                System.Runtime.Caching.MemoryCache.Default.Get("AcceptToken");
            if (accessToken != null && accessToken.IsValid())
            {
                return accessToken.AccessToken;
            }
            // 从微信服务器取 access_token 
            string targetUrl = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", wx_appid, wx_secret);
            try
            {
                string jsonString = HttpUtil.GetHttpPostResultContent(targetUrl);
                var o = Newtonsoft.Json.Linq.JObject.Parse(jsonString);
                var jtokenAccessToken = o["access_token"];
                var jtokenExpires = o["expires_in"];
                if (jtokenAccessToken == null || jtokenExpires == null)
                {
                    throw new Exception("未能从微信服务器获取 access_token ！" + (jsonString != null ? jsonString : ""));
                }
                string access_token = jtokenAccessToken != null ? jtokenAccessToken.ToString().Trim() : "";
                int expiresIn = Convert.ToInt32(jtokenExpires.ToString());
                accessToken = new WeiXinModels.AccessTokenModel();
                accessToken.AccessToken = access_token;
                accessToken.ExpiresSecond = expiresIn;
                accessToken.IssueTime = DateTime.Now;

                SaveAcceptTokenToCache(accessToken);

                return access_token;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 将 AccessToken 缓存 
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <returns></returns>
        public static bool SaveAcceptTokenToCache(WeiXinModels.AccessTokenModel accessToken)
        {
            lock (syncLock)
            {
                try
                {
                    System.Runtime.Caching.MemoryCache.Default.Set("AcceptToken",
                    accessToken,
                    DateTime.Now.AddSeconds(accessToken.ExpiresSecond));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }

        public static string[] GetWXServerIPList(string access_token)
        {
            if (string.IsNullOrEmpty(access_token))
            {
                new ArgumentNullException("access_token");
            }
            string url = "https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token=" + access_token;
            try
            {
                string responseContent = HttpUtil.GetHttpGetResultContent(url);
                if (string.IsNullOrEmpty(responseContent))
                {
                    return null;
                }
                var jobj = Newtonsoft.Json.Linq.JObject.Parse(responseContent);
                var jArr = Newtonsoft.Json.Linq.JArray.Parse(jobj["ip_list"].ToString());
                if (jArr == null)
                {
                    throw new Exception("未能从微信服务器获取 ip_list ！" + (responseContent != null ? responseContent : ""));
                }
                string[] ipList = new string[jArr.Count];
                for (int i = 0; i < jArr.Count; i++)
                {
                    ipList[i] = jArr[i].ToString();
                }

                return ipList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 从微信服务器获取自定义菜单包装对象 
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <returns></returns>
        public static WeiXinModels.WxMenuWrap GetWxMenu(string access_token)
        {
            return new WxMenuHelper().Get(access_token);
        }
        /// <summary>
        /// 创建自定义菜单
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="menu">微信自定义菜单对象</param>
        /// <returns></returns>
        public static bool CreateWxMenu(string access_token, WeiXinModels.WxMenu menu)
        {
            return new WxMenuHelper().Create(access_token, menu);
        }
        /// <summary>
        /// 删除自定义菜单
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <returns></returns>
        public static bool DeleteWxMenu(string access_token)
        {
            return new WxMenuHelper().Delete(access_token);
        }
    }
}
