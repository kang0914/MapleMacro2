using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MapleMacro2.Utils
{
    public class SendMessageHelper
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        const uint MOUSEEVENTF_MOVE = 0x0001;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        const uint MOUSEEVENTF_XDOWN = 0x0080;
        const uint MOUSEEVENTF_XUP = 0x0100;
        const uint MOUSEEVENTF_WHEEL = 0x0800;
        const uint MOUSEEVENTF_HWHEEL = 0x01000;

        public static IntPtr FindWindow(string windowName)
        {
            IntPtr WindowName = FindWindow(null, windowName);
            if (WindowName == IntPtr.Zero)
            {
                //throw new Exception();
            }

            return WindowName;
        }

        public static void KeyboardPress(string windowName, Keys keyCode)
        {
            KeyboardPress(FindWindow(windowName), keyCode);
        }

        public static void KeyboardPress(IntPtr hWnd, Keys keyCode)
        {
            if (keyCode == Keys.LButton)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }
            else if (keyCode == Keys.RButton)
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            }
            else if (keyCode == Keys.MButton)
            {
                mouse_event(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
            }
            else
            { 
                // KeyDown
                PostMessage(hWnd, 0x100, (IntPtr)keyCode, (IntPtr)Data.KeyboardLParamMaps.GetLParam(keyCode));

                //키보드 Up/Down 간격은 60~100ms 사이
                var randDealy = new Random().Next(60, 100);
                System.Threading.Thread.Sleep(randDealy);

                // KeyUp
                PostMessage(hWnd, 0x101, (IntPtr)keyCode, (IntPtr)Data.KeyboardLParamMaps.GetLParam(keyCode));
            }
        }

        public static void KeyboardDown(string windowName, Keys keyCode)
        {
            KeyboardDown(FindWindow(windowName), keyCode);
        }

        public static void KeyboardDown(IntPtr hWnd, Keys keyCode)
        {
            if (keyCode == Keys.LButton)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            }
            else if (keyCode == Keys.RButton)
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
            }
            else if (keyCode == Keys.MButton)
            {
                mouse_event(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
            }
            else
            {
                // KeyDown
                PostMessage(hWnd, 0x100, (IntPtr)keyCode, (IntPtr)Data.KeyboardLParamMaps.GetLParam(keyCode));
            }
        }

        public static void KeyboardUp(string windowName, Keys keyCode)
        {
            KeyboardUp(FindWindow(windowName), keyCode);
        }

        public static void KeyboardUp(IntPtr hWnd, Keys keyCode)
        {
            if (keyCode == Keys.LButton)
            {
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }
            else if (keyCode == Keys.RButton)
            {
                mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            }
            else if (keyCode == Keys.MButton)
            {
                mouse_event(MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
            }
            else
            {
                // KeyUp
                PostMessage(hWnd, 0x101, (IntPtr)keyCode, (IntPtr)Data.KeyboardLParamMaps.GetLParam(keyCode));
            }
        }

        public static void KeyboardDownEx(string windowName, Keys keyCode, IntPtr lParam)
        {
            KeyboardDownEx(FindWindow(windowName), keyCode, lParam);
        }

        public static void KeyboardDownEx(IntPtr hWnd, Keys keyCode, IntPtr lParam)
        {
            if (keyCode == Keys.LButton)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            }
            else if (keyCode == Keys.RButton)
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
            }
            else if (keyCode == Keys.MButton)
            {
                mouse_event(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
            }
            else
            {
                // KeyDown
                PostMessage(hWnd, 0x100, (IntPtr)keyCode, lParam);
            }
        }
    }
}
