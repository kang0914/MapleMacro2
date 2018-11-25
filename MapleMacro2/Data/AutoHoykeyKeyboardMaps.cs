using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapleMacro2.Data
{
    public class AutoHoykeyKeyboardMaps
    {
        private static Dictionary<Keys, string> dic = new Dictionary<Keys, string>();

        static AutoHoykeyKeyboardMaps()
        {
            //dic[Keys.Modifiers]
            //dic[Keys.None]
            dic[Keys.LButton] = "LButton";
            dic[Keys.RButton] = "RButton";
            //dic[Keys.Cancel]
            dic[Keys.MButton] = "MButton";
            //dic[Keys.XButton1]
            //dic[Keys.XButton2]
            dic[Keys.Back] = "Backspace";
            dic[Keys.Tab] = "Tab";
            //dic[Keys.LineFeed]
            //dic[Keys.Clear]
            //dic[Keys.Return] = 0x1C0001;
            dic[Keys.Enter] = "Enter";
            dic[Keys.ShiftKey] = "Shift";
            dic[Keys.ControlKey] = "Ctrl";
            dic[Keys.Menu] = "AppsKey";
            dic[Keys.Pause] = "Pause";
            //dic[Keys.Capital] = 0x3A0001;
            dic[Keys.CapsLock] = "CapsLock";
            //dic[Keys.HangulMode]
            //dic[Keys.JunjaMode]
            //dic[Keys.FinalMode]
            //dic[Keys.HanjaMode]
            //dic[Keys.KanjiMode]
            dic[Keys.Escape] = "Esc";
            //dic[Keys.IMEConvert]
            //dic[Keys.IMENonconvert]
            //dic[Keys.IMEAccept]
            //dic[Keys.IMEModeChange]
            //dic[Keys.Space]
            //dic[Keys.Prior] = 0x1490001;
            dic[Keys.PageUp] = "PgUp";
            //dic[Keys.Next] = 0x1510001;
            dic[Keys.PageDown] = "PgDn";
            dic[Keys.End] = "End";
            dic[Keys.Home] = "Home";
            dic[Keys.Left] = "Left";
            dic[Keys.Up] = "Up";
            dic[Keys.Right] = "Right";
            dic[Keys.Down] = "Down";
            //dic[Keys.Select]
            //dic[Keys.Print] = 
            //dic[Keys.Execute]
            //dic[Keys.Snapshot]
            //dic[Keys.PrintScreen]
            dic[Keys.Insert] = "Ins";
            dic[Keys.Delete] = "Del";
            //dic[Keys.Help]
            dic[Keys.D0] = "0";
            dic[Keys.D1] = "1";
            dic[Keys.D2] = "2";
            dic[Keys.D3] = "3";
            dic[Keys.D4] = "4";
            dic[Keys.D5] = "5";
            dic[Keys.D6] = "6";
            dic[Keys.D7] = "7";
            dic[Keys.D8] = "8";
            dic[Keys.D9] = "9";
            dic[Keys.A] = "a";
            dic[Keys.B] = "b";
            dic[Keys.C] = "c";
            dic[Keys.D] = "d";
            dic[Keys.E] = "e";
            dic[Keys.F] = "f";
            dic[Keys.G] = "g";
            dic[Keys.H] = "h";
            dic[Keys.I] = "i";
            dic[Keys.J] = "j";
            dic[Keys.K] = "k";
            dic[Keys.L] = "l";
            dic[Keys.M] = "m";
            dic[Keys.N] = "n";
            dic[Keys.O] = "o";
            dic[Keys.P] = "p";
            dic[Keys.Q] = "q";
            dic[Keys.R] = "r";
            dic[Keys.S] = "s";
            dic[Keys.T] = "t";
            dic[Keys.U] = "u";
            dic[Keys.V] = "v";
            dic[Keys.W] = "w";
            dic[Keys.X] = "x";
            dic[Keys.Y] = "y";
            dic[Keys.Z] = "z";
            dic[Keys.LWin] = "LWin";
            dic[Keys.RWin] = "RWin";
            //dic[Keys.Apps] 
            //dic[Keys.Sleep]
            dic[Keys.NumPad0] = "Numpad0";
            dic[Keys.NumPad1] = "Numpad1";
            dic[Keys.NumPad2] = "Numpad2";
            dic[Keys.NumPad3] = "Numpad3";
            dic[Keys.NumPad4] = "Numpad4";
            dic[Keys.NumPad5] = "Numpad5";
            dic[Keys.NumPad6] = "Numpad6";
            dic[Keys.NumPad7] = "Numpad7";
            dic[Keys.NumPad8] = "Numpad8";
            dic[Keys.NumPad9] = "Numpad9";
            dic[Keys.Multiply] = "NumpadMult";
            dic[Keys.Add] = "NumpadAdd";
            //dic[Keys.Separator] = 
            dic[Keys.Subtract] = "NumpadSub";
            dic[Keys.Decimal] = "NumpadDot";
            dic[Keys.Divide] = "NumpadDiv";
            dic[Keys.F1] = "F1";
            dic[Keys.F2] = "F2";
            dic[Keys.F3] = "F3";
            dic[Keys.F4] = "F4";
            dic[Keys.F5] = "F5";
            dic[Keys.F6] = "F6";
            dic[Keys.F7] = "F7";
            dic[Keys.F8] = "F8";
            dic[Keys.F9] = "F9";
            dic[Keys.F10] = "F10";
            dic[Keys.F11] = "F11";
            dic[Keys.F12] = "F12";
            dic[Keys.F13] = "F13";
            dic[Keys.F14] = "F14";
            dic[Keys.F15] = "F15";
            dic[Keys.F16] = "F16";
            dic[Keys.F17] = "F17";
            dic[Keys.F18] = "F18";
            dic[Keys.F19] = "F19";
            dic[Keys.F20] = "F20";
            dic[Keys.F21] = "F21";
            dic[Keys.F22] = "F22";
            dic[Keys.F23] = "F23";
            dic[Keys.F24] = "F24";
            dic[Keys.NumLock] = "NumLock";
            dic[Keys.Scroll] = "ScrollLock";
            dic[Keys.LShiftKey] = "LShift";
            dic[Keys.RShiftKey] = "RShift";
            dic[Keys.LControlKey] = "LCtrl";
            dic[Keys.RControlKey] = "RCtrl";
            //dic[Keys.LMenu]
            //dic[Keys.RMenu]                
            //dic[Keys.BrowserBack]
            //dic[Keys.BrowserForward]
            //dic[Keys.BrowserRefresh]
            //dic[Keys.BrowserStop]
            //dic[Keys.BrowserSearch]
            //dic[Keys.BrowserFavorites]
            //dic[Keys.BrowserHome]
            //dic[Keys.VolumeMute]
            //dic[Keys.VolumeDown]
            //dic[Keys.VolumeUp]                
            //dic[Keys.MediaNextTrack]
            //dic[Keys.MediaPreviousTrack]
            //dic[Keys.MediaStop]
            //dic[Keys.MediaPlayPause]
            //dic[Keys.LaunchMail]
            //dic[Keys.SelectMedia]
            //dic[Keys.LaunchApplication1]
            //dic[Keys.LaunchApplication2]
            dic[Keys.OemSemicolon] = ";";
            //dic[Keys.Oem1]
            dic[Keys.Oemplus] = "+";
            dic[Keys.Oemcomma] = ",";
            dic[Keys.OemMinus] = "-";
            dic[Keys.OemPeriod] = ".";
            dic[Keys.OemQuestion] = "?";
            //dic[Keys.Oem2] = 
            dic[Keys.Oemtilde] = "~";
            //dic[Keys.Oem3]
            dic[Keys.OemOpenBrackets] = "{";
            //dic[Keys.Oem4]
            dic[Keys.OemPipe] = "|";
            //dic[Keys.Oem5]
            dic[Keys.OemCloseBrackets] = "}";
            //dic[Keys.Oem6]
            dic[Keys.OemQuotes] = "`";
            //dic[Keys.Oem7]
            //dic[Keys.Oem8]
            //dic[Keys.OemBackslash]
            //dic[Keys.Oem102]
            //dic[Keys.ProcessKey]
            //dic[Keys.Packet]
            //dic[Keys.Attn]
            //dic[Keys.Crsel]
            //dic[Keys.Exsel]
            //dic[Keys.EraseEof]
            //dic[Keys.Play]
            //dic[Keys.Zoom]
            //dic[Keys.NoName]
            //dic[Keys.Pa1]
            //dic[Keys.OemClear]
            //dic[Keys.KeyCode]
            //dic[Keys.Shift]
            //dic[Keys.Control]
            dic[Keys.Alt] = "Alt";
        }

        public static string Get(Keys keys)
        {
            return dic[keys];
        }
    }
}
