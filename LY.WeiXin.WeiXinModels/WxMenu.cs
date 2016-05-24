using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;

namespace LY.WeiXin.WeiXinModels
{
    /// <summary>
    /// 微信自定义菜单
    /// </summary>
    public class WxMenu
    {
        public List<WxMenuItem> button = new List<WxMenuItem>();

        public override string ToString()
        {
            if (this.button == null || this.button.Count <= 0)
            {
                return string.Empty;
            }
            if (this.button.Count > 3)
            {
                throw new Exception("一级菜单最多只能有3个！");
            }
            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(button);
            string res = "{\"button\" : " + jsonStr + "}";
            return res;
        }
    }
}
