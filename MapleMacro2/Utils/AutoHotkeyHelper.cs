using AutoHotkey.Interop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MapleMacro2.Utils
{
    public class AutoHotkeyHelper
    {
        public static Point? ImageSearch(int X1, int Y1, int X2, int Y2, string ImageFile)
        {
            return ImageSearch(X1, Y1, X2, Y2, 70, "*TransBlack", ImageFile);
        }

        public static Point? ImageSearch(int X1, int Y1, int X2, int Y2, int allowedNumber, string transN, string ImageFile)
        {
            var ahk = AutoHotkeyEngine.Instance;

            ahk.ExecRaw($"ImageSearch, OutputVarX, OutputVarY, {X1}, {Y1}, {X2}, {Y2}, *{allowedNumber} {transN} {ImageFile}");

            string tempOutputVarX = ahk.GetVar("OutputVarX");
            string tempOutputVarY = ahk.GetVar("OutputVarY");

            if(string.IsNullOrEmpty(tempOutputVarX))
                return null;

            return new Point() {X = Convert.ToInt32(tempOutputVarX), Y = Convert.ToInt32(tempOutputVarY) };
        }

        public static string PixelGetColor(int X, int Y)
        {
            var ahk = AutoHotkeyEngine.Instance;

            ahk.ExecRaw($"PixelGetColor, OutputVar, {X}, {Y}");

            string tempOutputVarX = ahk.GetVar("OutputVar");

            return tempOutputVarX;
        }

        public static string PixelGetColor2()
        {
            var ahk = AutoHotkeyEngine.Instance;

            //            ahk.ExecRaw(@"MouseGetPos, MouseX, MouseY
            //PixelGetColor, color, %MouseX%, %MouseY%, Alt RGB
            //MsgBox The color at the current cursor position is %color%.");

            ahk.ExecRaw(@"
MouseGetPos, MouseX, MouseY
MouseX:=MouseX-1
MouseY:=MouseY-1
PixelGetColor, color, %MouseX%, %MouseY%");

            //return ahk.GetVar("color") + ", x="+ahk.GetVar("MouseX") + ", y=" +ahk.GetVar("MouseY");
            return ahk.GetVar("color");
        }

        public static Point MouseGetPos()
        {
            var ahk = AutoHotkeyEngine.Instance;

            ahk.ExecRaw(@"MouseGetPos, MouseX, MouseY");

            var strMouseX = ahk.GetVar("MouseX");
            var strMouseY = ahk.GetVar("MouseY");

            return new Point() { X = Convert.ToInt32(strMouseX), Y = Convert.ToInt32(strMouseY) };
        }

        public static void SendWithSleep(Keys keys, int sleep = 200)
        {
            var ahk = AutoHotkeyEngine.Instance;
            
            ahk.ExecRaw($@"Send {{{keys.ToString()} down}}
Sleep {sleep}
Send {{{keys.ToString()} up}}
            ");
        }

        public static void ExecRaw(string code)
        {
            var ahk = AutoHotkeyEngine.Instance;

            ahk.ExecRaw(code);
        }

        public static Point? PixelSearch(int X1, int Y1, int X2, int Y2, Color colorID)
        {
            var ahk = AutoHotkeyEngine.Instance;

            string hexColorID = $"0x{colorID.B.ToString("X")}{colorID.G.ToString("X")}{colorID.R.ToString("X")}";

            ahk.ExecRaw($"PixelSearch, OutputVarX, OutputVarY, {X1}, {Y1}, {X2}, {Y2}, {hexColorID},0 ,Fast");

            string tempOutputVarX = ahk.GetVar("OutputVarX");
            string tempOutputVarY = ahk.GetVar("OutputVarY");

            if (string.IsNullOrEmpty(tempOutputVarX))
                return null;

            return new Point() { X = Convert.ToInt32(tempOutputVarX), Y = Convert.ToInt32(tempOutputVarY) };
        }
    }
}
