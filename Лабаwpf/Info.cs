using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labawpf
{
    public class Info
    {
        public uint Step { get; set; } = 0;
        public string InText { get; set; } = "";
        public string OutText { get; set; } = "";
        public bool Shipher { get; set; } = true;
        public string Simbols { get; set; } = "0123456789абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public bool Direction { get; set; } = true;
    }
}
