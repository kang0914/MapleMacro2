using MapleMacro2.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapleMacro2.UI
{
    public partial class F8000 : Form
    {
        public F8000()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer공격패턴1.Enabled = !timer공격패턴1.Enabled;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var color = AutoHotkeyHelper.PixelGetColor2();
            label1.Text = color;

            var tempColor = color.Substring(2);
            var tempColorB = color.Substring(2, 2);
            var tempColorG = color.Substring(4, 2);
            var tempColorR = color.Substring(6, 2);

            panel1.BackColor = Color.FromArgb(Int32.Parse(tempColorR, System.Globalization.NumberStyles.HexNumber),
                Int32.Parse(tempColorG, System.Globalization.NumberStyles.HexNumber),
                Int32.Parse(tempColorB, System.Globalization.NumberStyles.HexNumber));


            var point = AutoHotkeyHelper.MouseGetPos();

            labelMousePosition.Text = $"X:{point.X}, Y:{point.Y}";
        }

        private Point? PrevPointMinimapTitle = null;
        private Point? PrevPointUser = null;
        private Point? PrevPointRune = null;
        private Point? PrevPointHiddenStreet = null;
        private Point? PrevPointDiffUser = null;

        private void timerImageSearch_Tick(object sender, EventArgs e)
        {
            // minimap_title
            string img5 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_transblack.bmp";

            var pointMinimapTitle = AutoHotkeyHelper.ImageSearch(0, 0, 550, 150, img5);

            if (pointMinimapTitle.HasValue)
            {
                labelImageSearch.Text = $"X:{pointMinimapTitle.Value.X}, Y:{pointMinimapTitle.Value.Y}";
            }
            else
                labelImageSearch.Text = "not found.";

            // minimap_minimizebox
            string img6 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_minimizebox_enabled_tranblack.bmp";

            var pointMinimizeBox = AutoHotkeyHelper.ImageSearch(0, 0, 300, 150, img6);

            if (pointMinimizeBox.HasValue)
            {
                labelMinimizeBox.Text = $"X:{pointMinimizeBox.Value.X}, Y:{pointMinimizeBox.Value.Y}";
            }
            else
                labelMinimizeBox.Text = "not found.";

            // minimap_maxmizebox
            string img7 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_maximizebox_disabled_transblack.bmp";

            var pointMaximizeBox = AutoHotkeyHelper.ImageSearch(0, 0, 300, 150, img7);

            if (pointMaximizeBox.HasValue)
            {
                labelMaximizeBox.Text = $"X:{pointMaximizeBox.Value.X}, Y:{pointMaximizeBox.Value.Y}";
            }
            else
                labelMaximizeBox.Text = "not found.";


            // minimap_left top
            string img8 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_lefttop_transblack.bmp";

            var pointLeftTop = AutoHotkeyHelper.ImageSearch(0, 0, 300, 300, img8);

            if (pointLeftTop.HasValue)
            {
                labelLeftTop.Text = $"X:{pointLeftTop.Value.X}, Y:{pointLeftTop.Value.Y}";
            }
            else
                labelLeftTop.Text = "not found.";

            // minimap_left bottom(failed)
            string img9 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_leftbottom_transblack.bmp";

            var pointLeftBottom = AutoHotkeyHelper.ImageSearch(0, 0, 100, 500, img9);

            if (pointLeftBottom.HasValue)
            {
                labelLeftBottom.Text = $"X:{pointLeftBottom.Value.X}, Y:{pointLeftBottom.Value.Y}";
            }
            else
                labelLeftBottom.Text = "not found.";

            // minimap_right top
            string img10 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_righttop_transblack.bmp";

            var pointRightTop = AutoHotkeyHelper.ImageSearch(0, 0, 300, 300, img10);

            if (pointRightTop.HasValue)
            {
                labelRightTop.Text = $"X:{pointRightTop.Value.X}, Y:{pointRightTop.Value.Y}";
            }
            else
                labelRightTop.Text = "not found.";

            // minimap_right bottom
            string img11 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_rightbottom_transblack.bmp";

            var pointRightBottom = AutoHotkeyHelper.ImageSearch(0, 0, 300, 300, img11);

            if (pointRightBottom.HasValue)
            {
                labelRightBottom.Text = $"X:{pointRightBottom.Value.X}, Y:{pointRightBottom.Value.Y}";
            }
            else
                labelRightBottom.Text = "not found.";

            // minimap_user
            string img12 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_user_transblack3.bmp";

            var pointUser = AutoHotkeyHelper.ImageSearch(0, 0, 500, 500, img12);

            if (pointUser.HasValue)
            {
                labelUser.Text = $"X:{pointUser.Value.X}, Y:{pointUser.Value.Y}";
            }
            else
                labelUser.Text = "not found.";

            // minimap_right
            string img13 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_right_transblack.bmp";

            var pointRight = AutoHotkeyHelper.ImageSearch(0, 0, 500, 300, img13);

            if (pointRight.HasValue)
            {
                labelRight.Text = $"X:{pointRight.Value.X}, Y:{pointRight.Value.Y}";
            }
            else
                labelRight.Text = "not found.";

            // minimap_left
            string img14 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_left_transblack.bmp";

            var pointLeft = AutoHotkeyHelper.ImageSearch(0, 0, 300, 500, img14);

            if (pointLeft.HasValue)
            {
                labelLeft.Text = $"X:{pointLeft.Value.X}, Y:{pointLeft.Value.Y}";
            }
            else
                labelLeft.Text = "not found.";

            // minimap rune
            string img15 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_rune_transblack.bmp";

            var pointRune = AutoHotkeyHelper.ImageSearch(0, 0, 300, 500, img15);

            if (pointRune.HasValue)
            {
                labelRune.Text = $"X:{pointRune.Value.X}, Y:{pointRune.Value.Y}";
            }
            else
                labelRune.Text = "not found.";

            // minimap hidden street
            string img16 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_hiddenstreet_transblack.bmp";

            var pointHiddenStreet = AutoHotkeyHelper.ImageSearch(0, 0, 300, 500, img16);

            if (pointHiddenStreet.HasValue)
            {
                labelHiddenStreet.Text = $"X:{pointHiddenStreet.Value.X}, Y:{pointHiddenStreet.Value.Y}";
            }
            else
                labelHiddenStreet.Text = "not found.";

            // minimap diff user
            string img17 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_diff_user_transblack.bmp";

            var pointDiffUser = AutoHotkeyHelper.ImageSearch(0, 0, 300, 500, img17);

            if (pointDiffUser.HasValue)
            {
                labelDiffUser.Text = $"X:{pointDiffUser.Value.X}, Y:{pointDiffUser.Value.Y}";
            }
            else
                labelDiffUser.Text = "not found.";

            // 왼쪽/오른쪽 방향 바꾸기
            if (pointUser.HasValue && pointLeft.HasValue && pointUser.Value.X < (pointLeft.Value.X + 30))
            {
                AddLog("왼쪽에 도달");

                if (timer공격패턴1.Enabled)
                    AutoHotkeyHelper.SendWithSleep(Keys.Right);
            }

            if (pointUser.HasValue && pointRight.HasValue && pointUser.Value.X > (pointRight.Value.X - 30))
            {
                AddLog("오른쪽에 도달");

                if (timer공격패턴1.Enabled)
                    AutoHotkeyHelper.SendWithSleep(Keys.Left);
            }

            if (pointMinimapTitle.HasValue && (PrevPointRune.HasValue == false) && pointRune.HasValue)
            {
                AddLog("룬이 생성됨.");
            }

            if (pointMinimapTitle.HasValue && (PrevPointHiddenStreet.HasValue == false) && pointHiddenStreet.HasValue)
            {
                AddLog("히든 스트리트가 생성됨.");
            }

            if (pointMinimapTitle.HasValue && (PrevPointDiffUser.HasValue == false) && pointDiffUser.HasValue)
            {
                AddLog("다른 유저가 나타남.");
            }

            PrevPointMinimapTitle = pointMinimapTitle;
            PrevPointUser = pointUser;
            PrevPointRune = pointRune;
            PrevPointHiddenStreet = pointHiddenStreet;
            PrevPointDiffUser = pointDiffUser;

            // HP, MP 
            //var findPoint = AutoHotkeyHelper.PixelSearch(620, 759, 780, 759, Color.FromArgb(0x4F, 0x4D, 0x52));
            int findMPPercent = 0;

            for (int i = 620; i <= 780; i = i + 20)
            {
                var color = AutoHotkeyHelper.PixelGetColor(i, 759);

                if (color == "0x524D4F")
                {
                    findMPPercent = i;
                    break;
                }
            }

            if (findMPPercent != 0)
            {
                var percent = (int)(((double)(findMPPercent - 620) / (double)(780 - 620)) * 100);

                labelPixelSearch.Text = percent.ToString();

                if (percent < 20)
                    AutoHotkeyHelper.ExecRaw(@"Send {Del}");
            }
            else
                labelPixelSearch.Text = "not found";

            // HP
            int findHPPercent = 0;

            for (int i = 620; i <= 780; i = i + 20)
            {
                var color = AutoHotkeyHelper.PixelGetColor(i, 743);

                if (color == "0x524D4F")
                {
                    findHPPercent = i;
                    break;
                }
            }

            if (findHPPercent != 0)
            {
                var percent = (int)(((double)(findHPPercent - 620) / (double)(780 - 620)) * 100);

                labelPixelSearchHP.Text = percent.ToString();

                if (percent < 50)
                    AutoHotkeyHelper.ExecRaw(@"Send {End}");
            }
            else
                labelPixelSearchHP.Text = "not found";
        }

        private void AddLog(string message)
        {
            textBoxLog.Text += string.Format("[{0}] {1}\r\n", DateTime.Now.ToString("HH:mm:ss"), message);
            textBoxLog.SelectionStart = textBoxLog.Text.Length;
            textBoxLog.ScrollToCaret();
        }

        private void timer공격패턴1_Tick(object sender, EventArgs e)
        {
            AutoHotkeyHelper.ExecRaw(textBox공격패턴_1.Text);

            AddLog("공격패턴 1 실행");
        }

        private void button채널변경_Click(object sender, EventArgs e)
        {
            AutoHotkeyHelper.ExecRaw(@"Send {-}
Sleep 500
Send {Right}
Sleep 500
Send {Enter}");
        }

        private void F8000_Load(object sender, EventArgs e)
        {
            textBox공격패턴_1.Text = Properties.Settings.Default.SCRIPT_공격패턴_1;
        }

        private void F8000_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SCRIPT_공격패턴_1 = textBox공격패턴_1.Text;

            Properties.Settings.Default.Save();
        }
    }
}
