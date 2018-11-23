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

        bool 공격방향_오른쪽에서_왼쪽으로 = true;

        string tmr공격패턴_1_script = "";
        string tmr공격패턴_2_script = "";

        private void button1_Click(object sender, EventArgs e)
        {
            //timer공격패턴1.Interval = (int)numericUpDown공격패턴1.Value;
            //timer공격패턴1.Enabled = !timer공격패턴1.Enabled;
            
            tmr공격패턴_1_script = textBox공격패턴_1.Text;
            tmr공격패턴_2_script = textBox공격패턴_2.Text;
            tmrMacro.Interval = (int)numericUpDownMacroInterval.Value;
            tmrMacro.Enabled = !tmrMacro.Enabled;

            if (tmrMacro.Enabled)
                AddLog("매크로 시작");
            else
                AddLog("매크로 종료");
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

        Core.MiniMapWatcher miniMapWatcher = new Core.MiniMapWatcher();
        Core.HPMPWatcher hPMPWatcher = new Core.HPMPWatcher();
        System.Timers.Timer tmrMacro = new System.Timers.Timer();

        private void AddLog(string message)
        {
            Invoke(new Action(() =>
            {
                textBoxLog.Text += string.Format("[{0}] {1}\r\n", DateTime.Now.ToString("HH:mm:ss"), message);
                textBoxLog.SelectionStart = textBoxLog.Text.Length;
                textBoxLog.ScrollToCaret();
            }));
        }

        private void timer공격패턴1_Tick(object sender, EventArgs e)
        {
            if(공격방향_오른쪽에서_왼쪽으로)
            { 
                AutoHotkeyHelper.ExecRaw(textBox공격패턴_1.Text);

                AddLog("공격패턴 1 실행");
            }
            else
            { 
                AutoHotkeyHelper.ExecRaw(textBox공격패턴_2.Text);

                AddLog("공격패턴 2 실행");
            }
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
            numericUpDownMacroInterval.Value = Properties.Settings.Default.MACRO_TIMER_INTERVAL;

            textBox공격패턴_1.Text = Properties.Settings.Default.SCRIPT_공격패턴_1;
            textBox공격패턴_2.Text = Properties.Settings.Default.SCRIPT_공격패턴_2;

            miniMapWatcher.화면_오른쪽에_도달_시 += MiniMapWatcher_화면_오른쪽에_도달_시;
            miniMapWatcher.화면_왼쪽에_도달_시 += MiniMapWatcher_화면_왼쪽에_도달_시;
            miniMapWatcher.룬_생성_시 += MiniMapWatcher_룬_생성_시;
            miniMapWatcher.다른_유저가_존재_시 += MiniMapWatcher_다른_유저가_존재_시;
            miniMapWatcher.히든_스트리트_생성_시 += MiniMapWatcher_히든_스트리트_생성_시;
            miniMapWatcher.Tick += MiniMapWatcher_Tick;
            miniMapWatcher.Start();

            //hPMPWatcher.HP_변경_시 += HPMPWatcher_HP_변경_시;
            //hPMPWatcher.MP_변경_시 += HPMPWatcher_MP_변경_시;
            //hPMPWatcher.Start();

            tmrMacro.Elapsed += TmrMacro_Elapsed;
        }

        private void TmrMacro_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (공격방향_오른쪽에서_왼쪽으로)
            {
                AutoHotkeyHelper.ExecRaw(tmr공격패턴_1_script);

                Invoke(new Action(() =>
                {
                    AddLog("공격패턴 1 실행");
                }));
            }
            else
            {
                AutoHotkeyHelper.ExecRaw(tmr공격패턴_2_script);

                Invoke(new Action(() =>
                {
                    AddLog("공격패턴 2 실행");
                }));
            }
        }

        private void HPMPWatcher_HP_변경_시(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                labelPixelSearchHP.Text = hPMPWatcher.CurrentHPPercent.ToString();
            }));

            if (hPMPWatcher.CurrentHPPercent < 50)
                AutoHotkeyHelper.ExecRaw(@"Send {End}");
        }

        private void HPMPWatcher_MP_변경_시(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                labelPixelSearch.Text = hPMPWatcher.CurrentMPPercent.ToString();
            }));

            if (hPMPWatcher.CurrentMPPercent < 20)
                AutoHotkeyHelper.ExecRaw(@"Send {Del}");
        }

        private void F8000_FormClosing(object sender, FormClosingEventArgs e)
        {
            miniMapWatcher.Stop();
            hPMPWatcher.Stop();

            Properties.Settings.Default.MACRO_TIMER_INTERVAL = (int)numericUpDownMacroInterval.Value;

            Properties.Settings.Default.SCRIPT_공격패턴_1 = textBox공격패턴_1.Text;
            Properties.Settings.Default.SCRIPT_공격패턴_2 = textBox공격패턴_2.Text;

            Properties.Settings.Default.Save();
        }

        private void MiniMapWatcher_Tick(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                // minimap_title
                if (miniMapWatcher.CourrentPointMinimapTitle.HasValue)
                    labelImageSearch.Text = $"X:{miniMapWatcher.CourrentPointMinimapTitle.Value.X}, Y:{miniMapWatcher.CourrentPointMinimapTitle.Value.Y}";
                else
                    labelImageSearch.Text = "";

                // minimap_right
                if (miniMapWatcher.CourrentPointRight.HasValue)
                    labelRight.Text = $"X:{miniMapWatcher.CourrentPointRight.Value.X}, Y:{miniMapWatcher.CourrentPointRight.Value.Y}";
                else
                    labelRight.Text = "";

                // minimap_left
                if (miniMapWatcher.CourrentPointLeft.HasValue)
                    labelLeft.Text = $"X:{miniMapWatcher.CourrentPointLeft.Value.X}, Y:{miniMapWatcher.CourrentPointLeft.Value.Y}";
                else
                    labelLeft.Text = "";

                // minimap_user
                if (miniMapWatcher.CourrentPointUser.HasValue)
                    labelUser.Text = $"X:{miniMapWatcher.CourrentPointUser.Value.X}, Y:{miniMapWatcher.CourrentPointUser.Value.Y}";
                else
                    labelUser.Text = "";

                // minimap rune
                if (miniMapWatcher.CourrentPointRune.HasValue)
                    labelRune.Text = $"X:{miniMapWatcher.CourrentPointRune.Value.X}, Y:{miniMapWatcher.CourrentPointRune.Value.Y}";
                else
                    labelRune.Text = "";

                // minimap hidden street
                if (miniMapWatcher.CourrentPointHiddenStreet.HasValue)
                    labelHiddenStreet.Text = $"X:{miniMapWatcher.CourrentPointHiddenStreet.Value.X}, Y:{miniMapWatcher.CourrentPointHiddenStreet.Value.Y}";
                else
                    labelHiddenStreet.Text = "";

                // minimap diff user
                if (miniMapWatcher.CourrentPointDiffUser.HasValue)
                    labelDiffUser.Text = $"X:{miniMapWatcher.CourrentPointDiffUser.Value.X}, Y:{miniMapWatcher.CourrentPointDiffUser.Value.Y}";
                else
                    labelDiffUser.Text = "";
            }));
        }

        private void MiniMapWatcher_히든_스트리트_생성_시(object sender, EventArgs e)
        {
            AddLog("히든 스트리트가 생성됨.");
        }

        private void MiniMapWatcher_다른_유저가_존재_시(object sender, EventArgs e)
        {
            AddLog("다른 유저가 나타남.");
        }

        private void MiniMapWatcher_룬_생성_시(object sender, EventArgs e)
        {
            AddLog("룬이 생성됨.");
        }

        private void MiniMapWatcher_화면_왼쪽에_도달_시(object sender, EventArgs e)
        {
            AddLog("왼쪽에 도달");

            //AutoHotkeyHelper.SendWithSleep(Keys.Right);

            공격방향_오른쪽에서_왼쪽으로 = true;
        }

        private void MiniMapWatcher_화면_오른쪽에_도달_시(object sender, EventArgs e)
        {
            AddLog("오른쪽에 도달");

            //AutoHotkeyHelper.SendWithSleep(Keys.Left);

            공격방향_오른쪽에서_왼쪽으로 = false;
        }
    }
}
