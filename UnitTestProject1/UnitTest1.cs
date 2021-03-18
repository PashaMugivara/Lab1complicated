using System;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labawpf;

namespace dsfkdk
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            var main = new MainWindow();
            string text = "";
            main.cezar.Step = 3;
            main.GetStep();
            main.Open_File(this, new RoutedEventArgs());
            main.DirRight(this, new RoutedEventArgs());
            main.Shifrate(this, new RoutedEventArgs());
            main.AlgorithmA(this, new RoutedEventArgs());
            main.Button_Click(this, new RoutedEventArgs());
            text = main.Encrypt(main.cezar.InText, main.cezar.Step, true);//Шифрование вправо. Алгоритм по умолчанию
            Assert.AreEqual(text, main.cezar.OutText, "Результат не верен");
        }
        [TestMethod]
        public void TestMethod2()
        {
            var main = new MainWindow();
            string text = "";
            main.cezar.Step = 2;
            main.GetStep();
            main.Open_File(this, new RoutedEventArgs());
            main.DirLeft(this, new RoutedEventArgs());
            main.Shifrate(this, new RoutedEventArgs());
            main.AlgorithmA(this, new RoutedEventArgs());
            main.Button_Click(this, new RoutedEventArgs());
            text = main.Encrypt(main.cezar.InText, main.cezar.Step, false);//Шифрование влево. Алгоритм по умолчанию
            Assert.AreEqual(text, main.cezar.OutText, "Результат не верен");
        }
        [TestMethod]
        public void TestMethod3()
        {
            var main = new MainWindow();
            string text = "";
            main.cezar.Step = 2;
            main.GetStep();
            main.Open_File(this, new RoutedEventArgs());
            main.DirRight(this, new RoutedEventArgs());
            main.Dishifrate(this, new RoutedEventArgs());
            main.AlgorithmB(this, new RoutedEventArgs());
            main.Button_Click(this, new RoutedEventArgs());
            text = main.Encrypt(main.cezar.InText, main.cezar.Step, false);//Дишифрование вправо. Алгоритм "цифры и буквы отдельно"
            Assert.AreEqual(text, main.cezar.OutText, "Результат не верен");
        }
        [TestMethod]
        public void TestMethod4()
        {
            var main = new MainWindow();
            string text = "";
            main.cezar.Step = 2;
            main.GetStep();
            main.Open_File(this, new RoutedEventArgs());
            main.DirLeft(this, new RoutedEventArgs());
            main.Dishifrate(this, new RoutedEventArgs());
            main.AlgorithmB(this, new RoutedEventArgs());
            main.Button_Click(this, new RoutedEventArgs());
            text = main.Encrypt(main.cezar.InText, main.cezar.Step, true);// Дишифрование влево. Алгоритм "цифры и буквы отдельно"
            Assert.AreEqual(text, main.cezar.OutText, "Результат не верен");
        }
    }
}
