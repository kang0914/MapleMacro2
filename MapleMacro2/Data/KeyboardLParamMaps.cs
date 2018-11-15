using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapleMacro2.Data
{
    public class KeyboardLParamMaps
    {
        private static Dictionary<Keys, long> dic = new Dictionary<Keys, long>();

        static KeyboardLParamMaps()
        {
            //dic[Keys.Modifiers]
            //dic[Keys.None]
            dic[Keys.LButton] = 0x00;
            dic[Keys.RButton] = 0x00;
            //dic[Keys.Cancel]
            dic[Keys.MButton] = 0x00;
            //dic[Keys.XButton1]
            //dic[Keys.XButton2]
            dic[Keys.Back] = 0xE0010;
            dic[Keys.Tab] = 0xF0001;
            //dic[Keys.LineFeed]
            //dic[Keys.Clear]
            dic[Keys.Return] = 0x1C0001;
            dic[Keys.Enter] = 0x1C0001;
            dic[Keys.ShiftKey] = 0x2A0001;
            dic[Keys.ControlKey] = 0x1D0001;
            dic[Keys.Menu] = 0x1D0001;
            dic[Keys.Pause] = 0x450001;
            dic[Keys.Capital] = 0x3A0001;
            dic[Keys.CapsLock] = 0x3A0001;
            //dic[Keys.HangulMode]
            //dic[Keys.JunjaMode]
            //dic[Keys.FinalMode]
            //dic[Keys.HanjaMode]
            //dic[Keys.KanjiMode]
            dic[Keys.Escape] = 0x10001;
            //dic[Keys.IMEConvert]
            //dic[Keys.IMENonconvert]
            //dic[Keys.IMEAccept]
            //dic[Keys.IMEModeChange]
            //dic[Keys.Space]
            dic[Keys.Prior] = 0x1490001;
            dic[Keys.PageUp] = 0x1490001;
            dic[Keys.Next] = 0x1510001;
            dic[Keys.PageDown] = 0x1510001;
            dic[Keys.End] = 0x14F0001;
            dic[Keys.Home] = 0x1470001;
            dic[Keys.Left] = 0x14B0001;
            dic[Keys.Up] = 0x1480001;
            dic[Keys.Right] = 0x14D0001;
            dic[Keys.Down] = 0x1400001;
            //dic[Keys.Select]
            //dic[Keys.Print] = 
            //dic[Keys.Execute]
            //dic[Keys.Snapshot]
            //dic[Keys.PrintScreen]
            dic[Keys.Insert] = 0x1520001;
            dic[Keys.Delete] = 0x1530001;
            //dic[Keys.Help]
            dic[Keys.D0] = 0xB0001;
            dic[Keys.D1] = 0x20001;
            dic[Keys.D2] = 0x30001;
            dic[Keys.D3] = 0x40001;
            dic[Keys.D4] = 0x50001;
            dic[Keys.D5] = 0x60001;
            dic[Keys.D6] = 0x70001;
            dic[Keys.D7] = 0x80001;
            dic[Keys.D8] = 0x90001;
            dic[Keys.D9] = 0xA0001;
            dic[Keys.A] = 0x1E0001;
            dic[Keys.B] = 0x300001;
            dic[Keys.C] = 0x2E0001;
            dic[Keys.D] = 0x200001;
            dic[Keys.E] = 0x120001;
            dic[Keys.F] = 0x210001;
            dic[Keys.G] = 0x220001;
            dic[Keys.H] = 0x230001;
            dic[Keys.I] = 0x170001;
            dic[Keys.J] = 0x240001;
            dic[Keys.K] = 0x250001;
            dic[Keys.L] = 0x260001;
            dic[Keys.M] = 0x320001;
            dic[Keys.N] = 0x310001;
            dic[Keys.O] = 0x180001;
            dic[Keys.P] = 0x190001;
            dic[Keys.Q] = 0x100001;
            dic[Keys.R] = 0x130001;
            dic[Keys.S] = 0x1F0001;
            dic[Keys.T] = 0x140001;
            dic[Keys.U] = 0x160001;
            dic[Keys.V] = 0x2F0001;
            dic[Keys.W] = 0x110001;
            dic[Keys.X] = 0x2D0001;
            dic[Keys.Y] = 0x150001;
            dic[Keys.Z] = 0x2C0001;
            dic[Keys.LWin] = 0x15B0001;
            dic[Keys.RWin] = 0x15C0001;
            //dic[Keys.Apps] 
            //dic[Keys.Sleep]
            dic[Keys.NumPad0] = 0x520001;
            dic[Keys.NumPad1] = 0x4F0001;
            dic[Keys.NumPad2] = 0x500001;
            dic[Keys.NumPad3] = 0x510001;
            dic[Keys.NumPad4] = 0x4B0001;
            dic[Keys.NumPad5] = 0x4C0001;
            dic[Keys.NumPad6] = 0x4D0001;
            dic[Keys.NumPad7] = 0x470001;
            dic[Keys.NumPad8] = 0x480001;
            dic[Keys.NumPad9] = 0x490001;
            dic[Keys.Multiply] = 0x370001;
            dic[Keys.Add] = 0x4E0001;
            //dic[Keys.Separator] = 
            dic[Keys.Subtract] = 0x4A0001;
            dic[Keys.Decimal] = 0x530001;
            dic[Keys.Divide] = 0x1350001;
            dic[Keys.F1] = 0x3B0001;
            dic[Keys.F2] = 0x3C0001;
            dic[Keys.F3] = 0x3D0001;
            dic[Keys.F4] = 0x3E0001;
            dic[Keys.F5] = 0x3F0001;
            dic[Keys.F6] = 0x400001;
            dic[Keys.F7] = 0x410001;
            dic[Keys.F8] = 0x420001;
            dic[Keys.F9] = 0x430001;
            dic[Keys.F10] =
            dic[Keys.F11] = 0x570001;
            dic[Keys.F12] = 0x580001;
            //dic[Keys.F13]
            //dic[Keys.F14]
            //dic[Keys.F15]
            //dic[Keys.F16]
            //dic[Keys.F17]
            //dic[Keys.F18]
            //dic[Keys.F19]
            //dic[Keys.F20]
            //dic[Keys.F21]
            //dic[Keys.F22]
            //dic[Keys.F23]
            //dic[Keys.F24]
            dic[Keys.NumLock] = 0x1450001;
            dic[Keys.Scroll] = 0x460001;
            dic[Keys.LShiftKey] = 0x2A0001;
            dic[Keys.RShiftKey] = 0x360001;
            dic[Keys.LControlKey] = 0x1D0001;
            dic[Keys.RControlKey] = 0x11D0001;
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
            dic[Keys.OemSemicolon] = 0x270001;
            //dic[Keys.Oem1]
            dic[Keys.Oemplus] = 0xD0001;
            dic[Keys.Oemcomma] = 0x330001;
            dic[Keys.OemMinus] = 0xC0001;
            dic[Keys.OemPeriod] = 0x340001;
            dic[Keys.OemQuestion] = 0x350001;
            //dic[Keys.Oem2] = 
            dic[Keys.Oemtilde] = 0x290001;
            //dic[Keys.Oem3]
            dic[Keys.OemOpenBrackets] = 0x1A0001;
            //dic[Keys.Oem4]
            dic[Keys.OemPipe] = 0x2B0001;
            //dic[Keys.Oem5]
            dic[Keys.OemCloseBrackets] = 0x1B0001;
            //dic[Keys.Oem6]
            dic[Keys.OemQuotes] = 0x280001;
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
            //dic[Keys.Alt]
        }

        public static long GetLParam(Keys keys)
        {
            return dic[keys];
        }
    }
}
