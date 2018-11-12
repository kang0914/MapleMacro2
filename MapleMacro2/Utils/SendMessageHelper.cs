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

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);

        public static IntPtr FindWindow(string windowName)
        {
            IntPtr WindowName = FindWindow(null, windowName);
            if (WindowName == IntPtr.Zero)
            {
                throw new Exception();
            }

            return WindowName;
        }

        public static void KeyboardDown(string windowName, Keys keyCode, long lParam)
        {
            KeyboardDown(FindWindow(windowName), keyCode, lParam);
        }

        public static void KeyboardDown(IntPtr hWnd, Keys keyCode, long lParam)
        {
            //PostMessage(WindowName, 0x100, (IntPtr)Keys.A, IntPtr.Zero);
            //System.Threading.Thread.Sleep(33);
            //PostMessage(WindowName, 0x101, (IntPtr)Keys.A, IntPtr.Zero);

            //PostMessage(hWnd, 0x100, (IntPtr)keyCode, (IntPtr)0x1e0001);

            //PostMessage(hWnd, 0x100, (IntPtr)0x41, (IntPtr)0x1e0001);

            //long lParam = CreateLParam((byte)Keys.IMEAccept, true);
            //long lParam = CreateLParam((byte)keyCode, true);

            PostMessage(hWnd, 0x100, (IntPtr)keyCode, (IntPtr)lParam);
            //System.Threading.Thread.Sleep(33);
            //PostMessage(hWnd, 0x101, (IntPtr)keyCode, (IntPtr)CreateLParam((byte)keyCode));
        }

        private static long CreateLParam(byte scanCode, bool isExtendedKey)
        {
            return CreateLParam(1, scanCode, isExtendedKey, false, false);
        }

        private static long CreateLParam(ushort repeatCount, byte scanCode, bool isExtendedKey, bool downBefore, bool state)
        {
            long value = MapVirtualKey((uint)scanCode, 0);
            
            value = repeatCount | (scanCode << 16);

            if (isExtendedKey)
                value = value | 0x01000000;

            if (downBefore)
                value = value | 0x40000000;

            if (state)
                value = value | 0x80000000;

            return value;
        }
    }
}
