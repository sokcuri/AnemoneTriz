using System;
using System.Windows.Forms;

namespace AnemoneTriz.Components
{
    public class Singleton<T> where T : Control, new()
    {
        private static T _instance;
        public static T Instance {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new T();

                return _instance;
            }
            private set { }
        }
        
        private Singleton() { }
    }
}