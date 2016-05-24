using LY.WeiXin.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LY.WeiXin.App.Areas.SysAdmin.Controllers
{
    public class WxApiController : Controller
    {

        public ActionResult ShowAccessToken()
        {
            string wx_appid = ConfigurationManager.AppSettings["wx_appid"];
            string wx_secret = ConfigurationManager.AppSettings["wx_appsecret"];
            string access_token = WeiXinUtility.GetAccessToken(wx_appid, wx_secret);

            return this.Content(access_token);
        }
    }
}