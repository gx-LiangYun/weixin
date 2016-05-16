using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LY.WeiXin.WeiXinModels
{
    public interface IWxMenu
    {
        WxMenuWrap Get(string access_token);
        bool Create(string access_token, WxMenu menu);
        bool Delete(string access_token);
    }
}
