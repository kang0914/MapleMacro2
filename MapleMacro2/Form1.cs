using MapleMacro2.Data;
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
            var defaultConfig = new MapleMacro2Config();
            CurrentConfig = defaultConfig;

            // 마지막 설정 파일 열기
            LoadLastOpenedConfigFile();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //핫키 해제
            UnregisterHotKey();

            // 설정 저장
            Properties.Settings.Default.Save();
        }

        private void LoadLastOpenedConfigFile()
        {
            var lastConfigFile = Properties.Settings.Default.LAST_OPENED_FILE;

            if (string.IsNullOrEmpty(lastConfigFile) == false)
            {
                if (System.IO.File.Exists(lastConfigFile))
                {
                    var readConfig = XMLHelper.ReadFromXmlFile<MapleMacro2Config>(lastConfigFile);

                    CurrentConfig = readConfig;

                    OPENED_FILE_NAME = lastConfigFile;

                    UpdateHotKey();
                }
            }
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

            var startKeys = KeysHelper.ClearModifiers(keysTextBox시작_키.SelectedKeys);
            var startModifiers = KeysHelper.CovertToHotKeyModifiers(keysTextBox시작_키.SelectedKeys);

            var endKeys = KeysHelper.ClearModifiers(keysTextBox종료_키.SelectedKeys);
            var endModifiers = KeysHelper.CovertToHotKeyModifiers(keysTextBox종료_키.SelectedKeys);

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
            timer1.Interval = delayTextBox기술_1_실행간격.ValueForInt;
            timer2.Interval = delayTextBox기술_2_실행간격.ValueForInt;
            timer3.Interval = delayTextBox기술_3_실행간격.ValueForInt;
            timer4.Interval = delayTextBox기술_4_실행간격.ValueForInt;

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
            if (delayTextBox설정_매크로_활성_시간.ValueForInt <= 0)
                return;

            timer매크로활성.Interval = delayTextBox설정_매크로_활성_시간.ValueForInt;
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
            CreateNewFile();
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenConfigFile();
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveConfigFile();
        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsConfigFile();
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
        
        private void toolStripButton새파일_Click(object sender, EventArgs e)
        {
            CreateNewFile();
        }

        private void toolStripButton열기_Click(object sender, EventArgs e)
        {
            OpenConfigFile();
        }

        private void toolStripButton저장_Click(object sender, EventArgs e)
        {
            SaveConfigFile();
        }

        private void toolStripButton정보_Click(object sender, EventArgs e)
        {

        }

        // 새 파일
        private void CreateNewFile()
        {
            IS_NEW_FILE = true;

            CurrentConfig = new MapleMacro2Config();
        }

        // 열기
        private void OpenConfigFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Config File|*.mm2c";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var readConfig = XMLHelper.ReadFromXmlFile<MapleMacro2Config>(ofd.FileName);

                CurrentConfig = readConfig;

                OPENED_FILE_NAME = ofd.FileName;

                UpdateHotKey();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // 저장
        private void SaveConfigFile()
        {
            if (IS_NEW_FILE)
            {
                SaveAsConfigFile();
            }
            else
            {
                try
                {
                    XMLHelper.WriteToXmlFile<MapleMacro2Config>(OPENED_FILE_NAME, CurrentConfig);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        // 다른 이름으로 저장
        private void SaveAsConfigFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Config File|*.mm2c";
            sfd.FileName = "제목없음";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                XMLHelper.WriteToXmlFile<MapleMacro2Config>(sfd.FileName, CurrentConfig);
                
                IS_NEW_FILE = false;
                OPENED_FILE_NAME = sfd.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // 프로그램 종료
        private void ExitApp()
        {
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;

            // 저장되지 않은 파일 확인 필요



            Properties.Settings.Default.LAST_OPENED_FILE = OPENED_FILE_NAME;

            EndMacro();

            Application.Exit();
        }

        private bool _IS_NEW_FILE;
        private bool IS_NEW_FILE
        {
            get { return _IS_NEW_FILE; }
            set
            {
                _IS_NEW_FILE = value;

                if (IS_NEW_FILE)
                    _OPENED_FILE_NAME = null;
            }
        }

        private string _OPENED_FILE_NAME;
        private string OPENED_FILE_NAME
        {
            get { return _OPENED_FILE_NAME; }
            set
            {
                _OPENED_FILE_NAME = value;

                if (String.IsNullOrEmpty(_OPENED_FILE_NAME))
                    _IS_NEW_FILE = true;
                else
                    _IS_NEW_FILE = false;
            }
        }

        private MapleMacro2Config CurrentConfig
        {
            get
            {
                return new MapleMacro2Config()
                {
                    KEYS_MACRO_START = keysTextBox시작_키.SelectedKeys,
                    KEYS_MACRO_END = keysTextBox종료_키.SelectedKeys,

                    TIME_MACRO_FUNC_ON = delayTextBox설정_매크로_활성_시간.ValueForInt,

                    FUNC_1 = new SingleKeysInfo() { KEYS = keysTextBox기술_1_키.SelectedKeys, TIME_DELAY = delayTextBox기술_1_실행간격.ValueForInt, IS_MACROD_FUNC = checkBox기술_1_매크로유무.Checked },
                    FUNC_2 = new SingleKeysInfo() { KEYS = keysTextBox기술_2_키.SelectedKeys, TIME_DELAY = delayTextBox기술_2_실행간격.ValueForInt, IS_MACROD_FUNC = checkBox기술_2_매크로유무.Checked },
                    FUNC_3 = new SingleKeysInfo() { KEYS = keysTextBox기술_3_키.SelectedKeys, TIME_DELAY = delayTextBox기술_3_실행간격.ValueForInt, IS_MACROD_FUNC = checkBox기술_3_매크로유무.Checked },
                    FUNC_4 = new SingleKeysInfo() { KEYS = keysTextBox기술_4_키.SelectedKeys, TIME_DELAY = delayTextBox기술_4_실행간격.ValueForInt, IS_MACROD_FUNC = checkBox기술_4_매크로유무.Checked }
                };
            }

            set
            {

                keysTextBox시작_키.SelectedKeys = value.KEYS_MACRO_START;
                keysTextBox종료_키.SelectedKeys = value.KEYS_MACRO_END;

                delayTextBox설정_매크로_활성_시간.ValueForInt = value.TIME_MACRO_FUNC_ON;

                keysTextBox기술_1_키.SelectedKeys = value.FUNC_1.KEYS;
                delayTextBox기술_1_실행간격.ValueForInt = value.FUNC_1.TIME_DELAY;
                checkBox기술_1_매크로유무.Checked = value.FUNC_1.IS_MACROD_FUNC;
                
                keysTextBox기술_2_키.SelectedKeys = value.FUNC_2.KEYS;
                delayTextBox기술_2_실행간격.ValueForInt = value.FUNC_2.TIME_DELAY;
                checkBox기술_2_매크로유무.Checked = value.FUNC_2.IS_MACROD_FUNC;

                keysTextBox기술_3_키.SelectedKeys = value.FUNC_3.KEYS;
                delayTextBox기술_3_실행간격.ValueForInt = value.FUNC_3.TIME_DELAY;
                checkBox기술_3_매크로유무.Checked = value.FUNC_3.IS_MACROD_FUNC;

                keysTextBox기술_4_키.SelectedKeys = value.FUNC_4.KEYS;
                delayTextBox기술_4_실행간격.ValueForInt = value.FUNC_4.TIME_DELAY;
                checkBox기술_4_매크로유무.Checked = value.FUNC_4.IS_MACROD_FUNC;
            }
        }

        #endregion 상단메뉴
    }
}
