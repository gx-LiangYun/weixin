﻿using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace LY.WeiXin.Common.Test
{
    [TestClass]
    public class WeiXinUtilityTest
    {
        private static string appid = "wx1f28144d7d9bc36e";
        private static string app_secret = "49bfdb43c6158c0a1d02926c43503da4";
        
        [TestMethod]
        public void GetAccessToken()
        {
            string access_token = WeiXinUtility.GetAccessToken("wx1f28144d7d9bc36e", "49bfdb43c6158c0a1d02926c43503da4");
            Assert.IsTrue(!string.IsNullOrEmpty(access_token));

            //string access_token2 = WeiXinUtility.GetAccessToken("wx1f28144d7d9bc36e", "49bfdb43c6158c0a1d02926c43503da4");
            //Assert.IsTrue(!string.IsNullOrEmpty(access_token2));
        }

        [TestMethod]
        public void GetWXServerIPListTest()
        {
            string[] ips = WeiXinUtility.GetWXServerIPList(WeiXinUtility.GetAccessToken(appid, app_secret));
            Assert.IsNotNull(ips);
        }
        [TestMethod]
        public void GetWxMenuTest()
        {
            var wrap = WeiXinUtility.GetWxMenu(WeiXinUtility.GetAccessToken(appid, app_secret));
            Assert.IsNotNull(wrap);
        }

        [TestMethod]
        public void CreateWxMenu()
        {
            string access_token = WeiXinUtility.GetAccessToken(appid, app_secret);
            var menu = new WeiXinModels.WxMenu();
            menu.button.Add(new WeiXinModels.WxMenuItem { name = "百度", type = "view", url = "http://www.baidu.com" });
            menu.button.Add(new WeiXinModels.WxMenuItem { name = "新浪", type = "view", url = "http://www.sina.com" });
            bool result = WeiXinUtility.CreateWxMenu(access_token, menu);
            Assert.IsTrue(result);
        }

        
    }
}
