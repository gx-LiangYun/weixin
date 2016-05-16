using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LY.WeiXin.WeiXinModels
{
    /// <summary>
    /// 微信 accessToken 类 
    /// </summary>
    public class WxAccessToken
    {
        /// <summary>
        /// acces_token 字符串
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// 取到 access_token 的时间
        /// </summary>
        public DateTime IssueTime { get; set; }

        /// <summary>
        /// 有效自然数
        /// </summary>
        public int ExpiresSecond { get; set; }

        /// <summary>
        /// 检测当前 AccessToken 是否有效
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(AccessToken) && IssueTime.AddSeconds(ExpiresSecond - 120) > DateTime.Now;
        }
    }
}
