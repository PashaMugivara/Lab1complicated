using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace Labawpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Info cezar = new Info();
        public MainWindow()
        {
            InitializeComponent();

  
        }
        private void Import()
        {
            string a;
            OpenFileDialog ofd = new OpenFileDialog(); // создаём процесс  
            ofd.ShowDialog(); // открываем проводник    
            cezar.InText = "";
            if (ofd.FileName != "") // проверка на выбор файла  
            {
                if (ofd.FileName.Substring(ofd.FileName.Length-3) == "txt")
                {
                    StreamReader sr = new StreamReader(ofd.FileName); // открываем файл   
                    while (!sr.EndOfStream) // перебираем строки, пока они не закончены       
                    {
                        a = char.ConvertFromUtf32(sr.Read());
                        cezar.InText += a;

                    }
                }
                else MessageBox.Show("Файл не формата txt");
            }
            else MessageBox.Show("Файл не выбран");
        }
        private void Export()
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName != "") // проверка на выбор файла  
            {
                string path = ofd.FileName; // имя файла     
                StreamWriter sw = new StreamWriter(path); // создаём файл     
                sw.WriteLine(cezar.OutText); // записываем логин       
                sw.Close(); // закрываем файл    
            }
            else MessageBox.Show("Файл не выбран");
        }



        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        public string Encrypt(string a, uint b, bool c)
        {
            bool IsUpper = false;
            char[] tempText = a.ToCharArray();
            char[] ABC = cezar.Simbols.ToCharArray();
            for (int i = 0; i < tempText.Length; i++)
            {
                int indexInABC = Array.IndexOf(ABC, Char.ToLower(tempText[i]));
                IsUpper = Char.IsUpper(tempText[i]);
                if (indexInABC >= 0)
                {
                    char symbol = ABC[c ? (b + indexInABC) % ABC.Length : (indexInABC - b) >= 0 ? indexInABC - b : ABC.Length + (indexInABC - b) % ABC.Length];
                    tempText[i] = IsUpper ? Char.ToUpper(symbol) : symbol;
                }
            }
            if (Algorithm2.IsChecked == true)
            {
                ABC = "0123456789".ToCharArray();
                for (int i = 0; i < tempText.Length; i++)
                {
                    int indexInABC = Array.IndexOf(ABC, Char.ToLower(tempText[i]));
                    IsUpper = Char.IsUpper(tempText[i]);
                    if (indexInABC >= 0)
                    {
                        char symbol = ABC[c ? (b + indexInABC) % ABC.Length : (indexInABC - b) >= 0 ? indexInABC - b : ABC.Length + (indexInABC - b) % ABC.Length];
                        tempText[i] = IsUpper ? Char.ToUpper(symbol) : symbol;
                    }
                }
            }
            return new string(tempText);
        }

        public virtual void Button_Click(object sender, RoutedEventArgs e)
        {

            var text = TextBox1.Text;
            if (uint.TryParse(text, out uint a) && a>=0)
            {
                cezar.Step = a;
                cezar.InText = TextBox2.Text;
                cezar.OutText = Encrypt(cezar.InText, cezar.Step, !(cezar.Direction ^ cezar.Shipher));
                TextBox3.Text = cezar.OutText;
            }
            else MessageBox.Show("Некорректный шаг");
        }



        public void Open_File(object sender, RoutedEventArgs e)
        {
            Import();
            TextBox2.Text = cezar.InText;
        }
        private void Save_File(object sender, RoutedEventArgs e)
        {
            Export();
        }
        public void Shifrate(object sender, RoutedEventArgs e)
        {
            Shifrate1.IsChecked = true; 
            Dishifrate1.IsChecked = false;
            cezar.Shipher = true;
        }
        public void Dishifrate(object sender, RoutedEventArgs e)
        {
            Shifrate1.IsChecked = false;
            Dishifrate1.IsChecked = true;
            cezar.Shipher = false;
        }
        public void DirRight(object sender, RoutedEventArgs e)
        {
            DirRight1.IsChecked = true;
            DirLeft1.IsChecked = false;
            cezar.Direction = true;
        }
        public void DirLeft(object sender, RoutedEventArgs e)
        {
            DirRight1.IsChecked = false;
            DirLeft1.IsChecked = true;
            cezar.Direction = false;
        }

        public void AlgorithmA(object sender, RoutedEventArgs e)
        {
            Algorithm1.IsChecked = true;
            Algorithm2.IsChecked = false;
            cezar.Simbols = "0123456789абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        }
        public void AlgorithmB(object sender, RoutedEventArgs e)
        {
            Algorithm1.IsChecked = false;
            Algorithm2.IsChecked = true;
            cezar.Simbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        }
        public void GetStep()
        {
            TextBox1.Text = cezar.Step.ToString();
        }
    }
}
