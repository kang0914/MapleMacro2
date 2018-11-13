using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MapleMacro2.Utils
{
    public class KeysHelper
    {
        public static string KeysToPrettyPrint(Keys keys)
        {
            var temp = keys.ToString();

            /*
             * 원본
             * A
             * A, Control
             * A, Control, Alt
             * 
             * 변경
             * A
             * A + Control
             * A + Control + Alt
             */
            temp = temp.Replace(", ", " + ");

            return temp;
        }

        public static Keys GetModifiers(Keys keys)
        {
            Keys modifiers = Keys.None;

            if ((keys & Keys.Control) == Keys.Control)
                modifiers = modifiers | Keys.Control;

            if ((keys & Keys.Alt) == Keys.Alt)
                modifiers = modifiers | Keys.Alt;

            if ((keys & Keys.Shift) == Keys.Shift)
                modifiers = modifiers | Keys.Shift;

            if ((keys & Keys.LWin) == Keys.LWin)
                modifiers = modifiers | Keys.LWin;

            return modifiers;
        }

        public static HotKeyHelper.KeyModifiers CovertToHotKeyModifiers(Keys keys)
        {
            HotKeyHelper.KeyModifiers modifiers = HotKeyHelper.KeyModifiers.None;

            if ((keys & Keys.Control) == Keys.Control)
                modifiers = modifiers | HotKeyHelper.KeyModifiers.Control;

            if ((keys & Keys.Alt) == Keys.Alt)
                modifiers = modifiers | HotKeyHelper.KeyModifiers.Alt;

            if ((keys & Keys.Shift) == Keys.Shift)
                modifiers = modifiers | HotKeyHelper.KeyModifiers.Shift;

            if ((keys & Keys.LWin) == Keys.LWin)
                modifiers = modifiers | HotKeyHelper.KeyModifiers.Windows;

            return modifiers;
        }
        public static Keys ClearModifiers(Keys keys)
        {
            Keys modifiers = Keys.None;

            if ((keys & Keys.Control) == Keys.Control)
                modifiers = modifiers ^ Keys.Control;

            if ((keys & Keys.Alt) == Keys.Alt)
                modifiers = modifiers ^ Keys.Alt;

            if ((keys & Keys.Shift) == Keys.Shift)
                modifiers = modifiers ^ Keys.Shift;

            if ((keys & Keys.LWin) == Keys.LWin)
                modifiers = modifiers ^ Keys.LWin;

            return modifiers;
        }
    }
}
