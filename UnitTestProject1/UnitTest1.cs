using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labawpf;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var main = new MainWindow();
            Assert.AreEqual(true, uint.TryParse(main.cezar.Step.ToString(), out _), "Это не число");
        }
        [TestMethod]
        public void TestMethod2()
        {
            var main = new MainWindow();
            Assert.AreEqual(true, !string.IsNullOrEmpty(main.cezar.Simbols) , "Отсутствует шифр");
        }
        [TestMethod]
        public void TestMethod3()
        {
            var main = new MainWindow();
            Assert.AreEqual(true, main.cezar.InText!=null, "Отсутствует файл");
        }
        [TestMethod]
        public void TestMethod4()
        {
            var main = new MainWindow();
            Assert.AreEqual(true, main.cezar.OutText != null, "Нет возможности создать новый файл");
        }
    }
}
