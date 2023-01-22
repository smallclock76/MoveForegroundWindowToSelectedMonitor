using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveAppToMonitor
{
    class MoveAppToMonitor : Singleton<MoveAppToMonitor>
    {
        [DllImport("user32.dll")]
        private static extern int RegisterHotKey(int hwnd, int id, int fsModifiers, int vk);
        //핫키제거
        [DllImport("user32.dll")]
        private static extern int UnregisterHotKey(int hwnd, int id);

        [DllImport("user32")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32")]
        private static extern bool MoveWindow(IntPtr hwnd, int X, int Y, uint nWidth, uint nHegith, bool bRepaint);

        override protected void init()
        {
        }

        public void DoRegisterHotKey(int hwnd)
        {
            // 0x0 : 조합키 없이 사용, 0x1: ALT, 0x2: Ctrl, 0x3: Shift 0x8: Windows key

            //RegisterHotKey(핸들러함수, 등록키의_ID, 조합키, 등록할_키)

            RegisterHotKey(hwnd, 0, 0x1, (int)Keys.D1);

            RegisterHotKey(hwnd, 1, 0x1, (int)Keys.D2);
        }

        public void DoUnregisterHotKey(int hwnd)
        {
            UnregisterHotKey(hwnd, 0); //이 폼에 ID가 0인 핫키 해제

            UnregisterHotKey(hwnd, 1);
        }
        public void MoveForegroundWindow(int monitor)
        {

            Screen[] scr = Screen.AllScreens;

            if (scr.Length > 1)
            {

                IntPtr hwnd = GetForegroundWindow();

                MoveWindow(hwnd, scr[monitor].Bounds.Location.X, scr[monitor].Bounds.Location.Y, (uint)scr[monitor].Bounds.Width,(uint)scr[monitor].Bounds.Height, true);

            }

        }
    }
}
