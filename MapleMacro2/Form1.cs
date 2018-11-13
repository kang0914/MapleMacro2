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
        private const string PROC_NAME_MAPLE_STORY = "MapleStory";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 핫키 등록
            RegisterHotKey();    
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //핫키 해제
            UnregisterHotKey();

            // 설정 저장
            Properties.Settings.Default.Save();
        }

        #region HotKey

        protected override void WndProc(ref Message message)
        {
            switch (message.Msg)
            {
                case HotKeyHelper.WM_HOTKEY:
                    { 
                        Keys key = (Keys)(((int)message.LParam >> 16) & 0xFFFF);
                        HotKeyHelper.KeyModifiers modifier = (HotKeyHelper.KeyModifiers)((int)message.LParam & 0xFFFF);                        

                        var startKeys = KeysHelper.ClearModifiers(keysTextBox시작_키.SelectedKeys);
                        var startModifiers = KeysHelper.CovertToHotKeyModifiers(keysTextBox시작_키.SelectedKeys);

                        var endKeys = KeysHelper.ClearModifiers(keysTextBox종료_키.SelectedKeys);
                        var endModifiers = KeysHelper.CovertToHotKeyModifiers(keysTextBox종료_키.SelectedKeys);

                        //if ((HotKeyHelper.KeyModifiers.Control | HotKeyHelper.KeyModifiers.Shift) == modifier && Keys.N == key)
                        //if ((HotKeyHelper.KeyModifiers.None) == modifier && Keys.F4 == key)
                        if (startModifiers == modifier &&
                            startKeys == key)
                        {
                            // 시작 키, 종료 키가 같을 경우에는 토글
                            if(startKeys == endKeys &&
                               startModifiers == endModifiers)
                            {
                                ToggleMacro();
                            }
                            else
                            {
                                StartMacro();
                            }
                        }
                        else if(endModifiers == modifier &&
                                endKeys == key)
                        {
                            EndMacro();
                        }
                    }
                    break;
            }
            base.WndProc(ref message);
        }

        private void RegisterHotKey()
        {
            //HotKeyHelper.RegisterHotKey(this.Handle, HotKeyHelper.HOTKEY_ID, HotKeyHelper.KeyModifiers.Control | HotKeyHelper.KeyModifiers.Shift, Keys.N);
            //HotKeyHelper.RegisterHotKey(this.Handle, HotKeyHelper.HOTKEY_ID, HotKeyHelper.KeyModifiers.None, Keys.F4);

            var startKeys = KeysHelper.ClearModifiers(Properties.Settings.Default.설정_시작_키);
            var startModifiers = KeysHelper.CovertToHotKeyModifiers(Properties.Settings.Default.설정_시작_키);

            var endKeys = KeysHelper.ClearModifiers(Properties.Settings.Default.설정_종료_키);
            var endModifiers = KeysHelper.CovertToHotKeyModifiers(Properties.Settings.Default.설정_종료_키);

            if (startKeys == endKeys &&
                startModifiers == endModifiers)
            {
                if (startKeys != Keys.None)
                    HotKeyHelper.RegisterHotKey(this.Handle, HotKeyHelper.HOTKEY_ID_START_MACRO, startModifiers, startKeys);
            }
            else
            {
                if(startKeys != Keys.None)
                    HotKeyHelper.RegisterHotKey(this.Handle, HotKeyHelper.HOTKEY_ID_START_MACRO, startModifiers, startKeys);

                if (endKeys != Keys.None)
                    HotKeyHelper.RegisterHotKey(this.Handle, HotKeyHelper.HOTKEY_ID_END_MACRO, endModifiers, endKeys);
            }

        }

        private void UnregisterHotKey()
        {
            HotKeyHelper.UnregisterHotKey(this.Handle, HotKeyHelper.HOTKEY_ID_START_MACRO);
            HotKeyHelper.UnregisterHotKey(this.Handle, HotKeyHelper.HOTKEY_ID_END_MACRO);
        }

        private void UpdateHotKey()
        {
            UnregisterHotKey();
            RegisterHotKey();
        }

        #endregion HotKey

        private void button시작_Click(object sender, EventArgs e)
        {
            StartMacro();
        }

        private void button중지_Click(object sender, EventArgs e)
        {
            EndMacro();
        }

        private bool IsRunMacro = false;

        private void StartMacro()
        {
            if (IsRunMacro)
                return;

            IsRunMacro = true;

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

        private void EndMacro()
        {
            if (IsRunMacro == false)
                return;

            IsRunMacro = false;

            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;

            toolStripProgressBar시작유무.Value = 0;
            toolStripStatusLabel시작유무.Text = "정지";
        }

        private void ToggleMacro()
        {
            if (IsRunMacro)
                EndMacro();
            else
                StartMacro();
        }

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

        private void keysTextBox시작_키_KeysChanged(object sender, EventArgs e)
        {
            UpdateHotKey();
        }

        private void keysTextBox종료_키_KeysChanged(object sender, EventArgs e)
        {
            UpdateHotKey();
        }

        #region 상단메뉴

        private void 새파일ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApp();
        }

        private void 도움말ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 홈페이지ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 업데이트확인ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // 새 파일
        private void CreateNewFile()
        {

        }

        // 열기
        private void OpenConfigFile()
        {

        }

        // 저장
        private void SaveConfigFile()
        {

        }

        // 다른 이름으로 저장
        private void SaveAsConfigFile()
        {

        }

        // 프로그램 종료
        private void ExitApp()
        {
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;

            // 저장되지 않은 파일 확인 필요

            EndMacro();

            Application.Exit();
        }

        #endregion 상단메뉴
    }
}
