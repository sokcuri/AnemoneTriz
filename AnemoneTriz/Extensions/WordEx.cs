using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnemoneTriz.Extensions
{
    public static class WordEx
    {
        public static int LowWord(this int number)
        { return (int)(number & 0x0000FFFF); }
        public static int HighWord(this int number)
        { return (int)(number & 0xFFFF0000) >> 16; }
    }
}
