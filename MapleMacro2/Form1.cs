using MapleMacro2.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapleMacro2
{
    public partial class Form1 : Form
    {
        private GlobalKeyboardHook _globalKeyboardHook;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //_globalKeyboardHook = new GlobalKeyboardHook();
            //_globalKeyboardHook.KeyboardPressed += OnKeyPressed;

            // 핫키 등록
            //HotKeyHelper.RegisterHotKey(this.Handle, HotKeyHelper.HOTKEY_ID, HotKeyHelper.KeyModifiers.Control | HotKeyHelper.KeyModifiers.Shift, Keys.N);
            HotKeyHelper.RegisterHotKey(this.Handle, HotKeyHelper.HOTKEY_ID, HotKeyHelper.KeyModifiers.None, Keys.F4);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_globalKeyboardHook?.Dispose();

            //핫키 해제
            HotKeyHelper.UnregisterHotKey(this.Handle, HotKeyHelper.HOTKEY_ID);

            Properties.Settings.Default.Save();
        }

        protected override void WndProc(ref Message message)
        {
            switch (message.Msg)
            {
                case HotKeyHelper.WM_HOTKEY:
                    Keys key = (Keys)(((int)message.LParam >> 16) & 0xFFFF);
                    HotKeyHelper.KeyModifiers modifier = (HotKeyHelper.KeyModifiers)((int)message.LParam & 0xFFFF);
                    //MessageBox.Show("HotKey Pressed :" + modifier.ToString() + " " + key.ToString());

                    //if ((HotKeyHelper.KeyModifiers.Control | HotKeyHelper.KeyModifiers.Shift) == modifier && Keys.N == key)
                    if ((HotKeyHelper.KeyModifiers.None) == modifier && Keys.F4 == key)
                    {
                        //Process.Start("notepad.exe");
                        //MessageBox.Show("");

                        if (!timer1.Enabled)
                            button시작_Click(null, null);
                        else
                            button중지_Click(null, null);
                    }

                    break;
            }
            base.WndProc(ref message);
        }

        private void button시작_Click(object sender, EventArgs e)
        {
            // 최초 실행
            timer1_Tick(null, null);
            timer2_Tick(null, null);
            timer3_Tick(null, null);
            timer4_Tick(null, null);

            // 실행 간격 적용
            timer1.Interval = Convert.ToInt32(textBox기술_1_실행간격.Text);
            timer2.Interval = Convert.ToInt32(textBox기술_2_실행간격.Text);
            timer3.Interval = Convert.ToInt32(textBox기술_3_실행간격.Text);
            timer4.Interval = Convert.ToInt32(textBox기술_4_실행간격.Text);

            // 타이머 활성화
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            timer4.Enabled = true;

            toolStripProgressBar시작유무.Value = 100;
            toolStripStatusLabel시작유무.Text = "동작 중...";
        }

        private void button중지_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;

            toolStripProgressBar시작유무.Value = 0;
            toolStripStatusLabel시작유무.Text = "정지";
        }

        private const string PROC_NAME_MAPLE_STORY = "MapleStory";

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer매크로활성.Enabled)
                return;

            if (checkBox기술_1_매크로유무.Checked)
                Start매크로활성();

            SendMessageHelper.KeyboardDown(PROC_NAME_MAPLE_STORY, Keys.A, 0x01E0001);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (checkBox기술_2_매크로유무.Checked)
                Start매크로활성();

            SendMessageHelper.KeyboardDown(PROC_NAME_MAPLE_STORY, Keys.Insert, 0x1520001);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (timer매크로활성.Enabled)
                return;

            if (checkBox기술_3_매크로유무.Checked)
                Start매크로활성();

            SendMessageHelper.KeyboardDown(PROC_NAME_MAPLE_STORY, Keys.Delete, 0x1530001);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (timer매크로활성.Enabled)
                return;

            if (checkBox기술_4_매크로유무.Checked)
                Start매크로활성();

            SendMessageHelper.KeyboardDown(PROC_NAME_MAPLE_STORY, Keys.Z, 0x02C0001);
        }

        private void Start매크로활성()
        {
            timer매크로활성.Interval = Convert.ToInt32(textBox설정_매크로_활성_시간.Text);
            timer매크로활성.Enabled = true;
        }

        private void End매크로활성()
        {
            timer매크로활성.Enabled = false;
        }

        private void timer매크로활성_Tick(object sender, EventArgs e)
        {
            End매크로활성();
        }

        #region 캡쳐

        private void button캡쳐_Click(object sender, EventArgs e)
        {
            ScreenCopy.Copy("test.png");
        }

        private void button캡쳐2_Click(object sender, EventArgs e)
        {
            ScreenCopy.Copy2("test.png");
        }

        #endregion 캡쳐

        #region hooking

        private void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            //Debug.WriteLine(e.KeyboardData.VirtualCode);

            if (e.KeyboardData.VirtualCode != GlobalKeyboardHook.VkSnapshot)
                return;

            // seems, not needed in the life.
            //if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.SysKeyDown &&
            //    e.KeyboardData.Flags == GlobalKeyboardHook.LlkhfAltdown)
            //{
            //    MessageBox.Show("Alt + Print Screen");
            //    e.Handled = true;
            //}
            //else

            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            {
                MessageBox.Show("Print Screen");
                e.Handled = true;
            }
        }

        #endregion hooking

    }
}
