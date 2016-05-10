using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LY.WeiXin.EFDAL;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace LY.WeiXin.EFDALTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            WXContext db = new WXContext();
            int c = db.SysConfigItem.Count();
            Assert.IsTrue(c >= 0);
            db.Dispose();
            
        }
    }
}
