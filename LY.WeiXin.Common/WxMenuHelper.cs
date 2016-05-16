using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;

namespace LY.WeiXin.Common
{
    class WxMenuHelper : WeiXinModels.IWxMenu
    {

        public WeiXinModels.WxMenuWrap Get(string access_token)
        {
            if (string.IsNullOrEmpty(access_token))
            {
                throw new ArgumentNullException("access_token");
            }
            string url = "https://api.weixin.qq.com/cgi-bin/menu/get?access_token=" + access_token;
            string responseContent = HttpUtil.GetHttpGetResultContent(url);
            WeiXinModels.WxMenuWrap wrap = Newtonsoft.Json.JsonConvert.DeserializeObject<WeiXinModels.WxMenuWrap>(responseContent);
            return wrap;
        }

        public bool Create(string access_token, WeiXinModels.WxMenu menu)
        {
            if (string.IsNullOrEmpty(access_token))
            {
                throw new ArgumentNullException("access_token");
            }
            if (menu == null || menu.button == null)
            {
                throw new ArgumentNullException("menu");
            }
            string url = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + access_token;
            return false;
        }

        public bool Delete(string access_token)
        {
            throw new NotImplementedException();
        }
    }
}
