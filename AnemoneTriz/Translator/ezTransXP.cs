using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AnemoneTriz.Translator
{
    static class ezTransXP
    {
        //[DllImport("J2KEngine.dll", EntryPoint = @"J2K_InitializeEx", CharSet = CharSet.Auto)]
        //public static extern int SendMessageRefRect(char *code, char *);

        public static ezTransXP_J2K J2K {
            get
            {
                return null;
            }
            set
            {

            }
        }
        public static ezTransXP_K2J K2J { get; set; }

        public static bool Initialized { get; private set; }

        public static bool Initialize()
        {
            return true;
        }

        public class ezTransXP_J2K
        {
            public bool Initialize()
            {
                return true;
            }

            public string Translate(string sourceText)
            {
                return "Translate";
            }
        }

        public class ezTransXP_K2J
        {
            public bool Initialize()
            {
                return true;
            }

            public string Translate(string sourceText)
            {
                return "Translate";
            }
        }
        
    }
}
