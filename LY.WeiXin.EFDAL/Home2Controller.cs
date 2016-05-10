using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using LY.WeiXin.Common;

namespace LY.WeiXin.Mvc.Controllers
{
    public class Home2Controller : Controller
    {
        [HttpGet]
        public ActionResult Index(string signature, string echostr, string timestamp, string nonce)
        {
            try
            {
                //string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "url.txt");
                //string txt = string.Format("{0}, {1}, {2}, {3}", signature, echostr, timestamp, nonce);
                //System.IO.File.WriteAllText(path, txt);

                string wx_token = System.Configuration.ConfigurationManager.AppSettings["wx_token"];
                if (WeiXinUtil.CheckSignature(signature, echostr, timestamp, nonce, wx_token))
                {
                    return this.Content(echostr);
                }
            }
            catch (Exception ex)
            {
                return this.Content(ex.Message);
            }

            return this.Content("");
        }

        [HttpPost, ActionName("Index")]
        public ActionResult Accept()
        {
            return this.View();
        }

        public ActionResult ShowAccessToken()
        {
            string wx_appid = ConfigurationManager.AppSettings["wx_appid"];
            string wx_secret = ConfigurationManager.AppSettings["wx_secret"];
            string access_token = WeiXinUtil.GetAccessToken(wx_appid, wx_secret);

            return this.Content(access_token);
        }
    }
}