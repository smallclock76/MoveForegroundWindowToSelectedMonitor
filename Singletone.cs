using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveAppToMonitor
{
    public class Singleton<T> where T : Singleton<T>, new()
    {
        static T mInstnace;
        public static T Instance
        {
            get
            {
                if (mInstnace == null)
                {
                    mInstnace = new T();
                    mInstnace.init();
                }

                return mInstnace;
            }
        }

        protected virtual void init()
        {

        }
    }
}
