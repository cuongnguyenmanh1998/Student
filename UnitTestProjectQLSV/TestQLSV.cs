using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLySinhVien;
namespace UnitTestProjectQLSV
{
    [TestClass]

    public class TestQLSV
    {
        [TestMethod]
        public void TestTC()
        {
            Assert.AreEqual("admin", "admin");
            Assert.AreEqual("123", "123");
        }
        [TestMethod]
        public void TestSaiTK()
        {
            Assert.AreEqual("admin", "admi");
            Assert.AreEqual("123", "123");
        }
        [TestMethod]
        public void TestSaiMK()
        {
            Assert.AreEqual("admin", "admin");
            Assert.AreEqual("123", "1111");
        }
        [TestMethod]
        public void TestSaiTKMK()
        {
            Assert.AreEqual("admin", "");
            Assert.AreEqual("123", "");
        }
        [TestMethod]
        public void TestSaiTK1()
        {
            Assert.AreEqual("admin", "");
            Assert.AreEqual("123", "123");
        }
        public void TestSaiMK1()
        {
            Assert.AreEqual("admin", "admin");
            Assert.AreEqual("123", "");
        }
        

    }
}
