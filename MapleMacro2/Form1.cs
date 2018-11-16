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
        private const string PROGRAM_NAME = "Maple Macro 2";

        //private const string PROCESS_NAME_TARGET = "MapleStory";
        private const string PROCESS_NAME_TARGET = "디아블로 III";

        public Form1()
        {
            InitializeComponent();

            IS_NEW_FILE = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var defaultConfig = new MapleMacro2Config();
            CurrentConfig = defaultConfig;

            if (Properties.Settings.Default.RECENTLY_OPENED_FILES == null)
                Properties.Settings.Default.RECENTLY_OPENED_FILES = new System.Collections.Specialized.StringCollection();

            // 마지막 설정 파일 열기
            LoadConfigFile(Properties.Settings.Default.LAST_OPENED_FILE);

            UpdateTitle();

            UpdateRecentlyOpenConfigFile();
        }

        private void UpdateRecentlyOpenConfigFile()
        {
            List<ToolStripMenuItem> toolStripMenuItems = new List<ToolStripMenuItem>();
            List<ToolStripMenuItem> toolStripMenuItems2 = new List<ToolStripMenuItem>();

            
            foreach (var item in Properties.Settings.Default.RECENTLY_OPENED_FILES)
            {
                var menu = new ToolStripMenuItem() { Text = item, Tag = item };
                menu.Click += (sender2, e2) =>
                {
                    var fileName = ((ToolStripMenuItem)sender2).Tag as string;

                    LoadConfigFile(fileName);
                };

                toolStripMenuItems.Add(menu);
            }

            
            foreach (var item in Properties.Settings.Default.RECENTLY_OPENED_FILES)
            {
                var menu = new ToolStripMenuItem() { Text = item, Tag = item };
                menu.Click += (sender2, e2) =>
                {
                    var fileName = ((ToolStripMenuItem)sender2).Tag as string;

                    LoadConfigFile(fileName);
                };

                toolStripMenuItems2.Add(menu);
            }

            toolStripMenuItems.Reverse();
            toolStripMenuItems2.Reverse();

            최근에사용한설정파일ToolStripMenuItem.DropDownItems.Clear();
            최근에사용한설정파일ToolStripMenuItem.DropDownItems.AddRange(toolStripMenuItems.ToArray());

            toolStripButton열기.DropDownItems.Clear();
            toolStripButton열기.DropDownItems.AddRange(toolStripMenuItems2.ToArray());
        }

        private void AddToRECENTLY_OPENED_FILES(string fileName)
        {
            // 기존 항목 삭제
            if(Properties.Settings.Default.RECENTLY_OPENED_FILES.Contains(fileName))
            {
                Properties.Settings.Default.RECENTLY_OPENED_FILES.Remove(fileName);
            }

            Properties.Settings.Default.RECENTLY_OPENED_FILES.Add(fileName);

            if (Properties.Settings.Default.RECENTLY_OPENED_FILES.Count > 10)
                Properties.Settings.Default.RECENTLY_OPENED_FILES.RemoveAt(0);

            Properties.Settings.Default.Save();

            UpdateRecentlyOpenConfigFile();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                if (CheckExit() == false)
                { 
                    e.Cancel = true;

                    return;
                }
            }

            // 마지막 파일명 저장
            Properties.Settings.Default.LAST_OPENED_FILE = OPENED_FILE_NAME;

            // 매크로 종료
            EndMacro();

            // 핫키 해제
            UnregisterHotKey();

            // 설정 저장
            Properties.Settings.Default.Save();
        }

        private void LoadConfigFile(string fileName)
        {
            var lastConfigFile = fileName;

            if (string.IsNullOrEmpty(lastConfigFile) == false)
            {
                if (System.IO.File.Exists(lastConfigFile))
                {
                    var readConfig = XMLHelper.ReadFromXmlFile<MapleMacro2Config>(lastConfigFile);

                    CurrentConfig = readConfig;

                    OPENED_FILE_NAME = lastConfigFile;

                    UpdateHotKey();

                    IS_CHANGED = false;

                    AddToRECENTLY_OPENED_FILES(OPENED_FILE_NAME);
                }
                else
                {
                    MessageBox.Show("파일을 찾을 수 없습니다.");
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

                        if (keysTextBox시작_키.Focused)
                        {
                            keysTextBox시작_키.SelectedKeys = key | KeysHelper.CovertToHotKeyModifiersForHelpers(modifier);
                            break;
                        }

                        if (keysTextBox종료_키.Focused)
                        {
                            keysTextBox종료_키.SelectedKeys = key | KeysHelper.CovertToHotKeyModifiersForHelpers(modifier);
                            break;
                        }

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
                            if (startKeys == endKeys &&
                               startModifiers == endModifiers)
                            {
                                ToggleMacro();
                            }
                            else
                            {
                                StartMacro();
                            }
                        }
                        else if (endModifiers == modifier &&
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
        private List<Timer> listKeyTimer = new List<Timer>();

        private void StartMacro()
        {
            if (IsRunMacro)
                return;

            IsRunMacro = true;
            
            Execute(CurrentConfig.FUNC_1);
            Execute(CurrentConfig.FUNC_2);
            Execute(CurrentConfig.FUNC_3);
            Execute(CurrentConfig.FUNC_4);
            Execute(CurrentConfig.FUNC_5);
            Execute(CurrentConfig.FUNC_6);

            toolStripProgressBar시작유무.Value = 100;
            toolStripStatusLabel시작유무.Text = "동작 중...";
        }

        private void EndMacro()
        {
            if (IsRunMacro == false)
                return;

            IsRunMacro = false;

            foreach (var tmr in listKeyTimer)
            {
                tmr.Stop();
                tmr.Enabled = false;
                tmr.Dispose();
            }
            listKeyTimer.Clear();

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

        private void Execute(SingleKeysInfo singleKeysInfo)
        {
            if (singleKeysInfo.KEYS == Keys.None || singleKeysInfo.TIME_DELAY == 0)
                return;

            // 최초 1회 실행
            SendMessageHelper.KeyboardDown(PROCESS_NAME_TARGET, singleKeysInfo.KEYS);

            // 타이머 설정
            Timer tmr = new Timer();

            tmr.Tick += (sender, e) =>
            {
                var tempTmr = sender as Timer;
                var tempSingleKeysInfo = tempTmr.Tag as SingleKeysInfo;

                if (timer매크로활성.Enabled)
                    return;

                if (tempSingleKeysInfo.IS_MACROD_FUNC)
                    Start매크로활성();

                SendMessageHelper.KeyboardDown(PROCESS_NAME_TARGET, tempSingleKeysInfo.KEYS);
            };

            tmr.Tag = singleKeysInfo;
            tmr.Interval = singleKeysInfo.TIME_DELAY;
            tmr.Enabled = true;

            listKeyTimer.Add(tmr);
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

        private void toolStripButton열기_ButtonClick(object sender, EventArgs e)
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

            IS_CHANGED = true;

            UpdateTitle();
        }

        // 열기
        private void OpenConfigFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Maple Macro2 Config File (*.mm2c)|*.mm2c";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var readConfig = XMLHelper.ReadFromXmlFile<MapleMacro2Config>(ofd.FileName);

                CurrentConfig = readConfig;

                OPENED_FILE_NAME = ofd.FileName;

                UpdateHotKey();

                IS_CHANGED = false;

                UpdateTitle();

                AddToRECENTLY_OPENED_FILES(OPENED_FILE_NAME);
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

                    IS_CHANGED = false;

                    UpdateTitle();

                    AddToRECENTLY_OPENED_FILES(OPENED_FILE_NAME);
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

            sfd.Filter = "Maple Macro2 Config File (*.mm2c)|*.mm2c";
            sfd.FileName = "제목없음";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                XMLHelper.WriteToXmlFile<MapleMacro2Config>(sfd.FileName, CurrentConfig);
                
                IS_NEW_FILE = false;
                OPENED_FILE_NAME = sfd.FileName;

                IS_CHANGED = false;

                UpdateTitle();

                AddToRECENTLY_OPENED_FILES(OPENED_FILE_NAME);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // 프로그램 종료
        private void ExitApp()
        {
            this.Close();
        }

        private bool CheckExit()
        {
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return false;

            // 저장되지 않은 파일 확인 필요
            if (IS_CHANGED)
            {
                if (MessageBox.Show("저장되지 않은 파일이 있습니다. 저장하시겠습니까?", "확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    SaveConfigFile();
                }
            }

            return true;
        }

        private bool _IS_CHANGED;
        private bool IS_CHANGED
        {
            get { return _IS_CHANGED; }
            set
            {
                _IS_CHANGED = value;

                UpdateTitle();
            }
        }


        private bool _IS_NEW_FILE;
        private bool IS_NEW_FILE
        {
            get { return _IS_NEW_FILE; }
            set
            {
                _IS_NEW_FILE = value;

                if (IS_NEW_FILE)
                {
                    _OPENED_FILE_NAME = null;
                    IS_CHANGED = true;
                }
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
                    FUNC_4 = new SingleKeysInfo() { KEYS = keysTextBox기술_4_키.SelectedKeys, TIME_DELAY = delayTextBox기술_4_실행간격.ValueForInt, IS_MACROD_FUNC = checkBox기술_4_매크로유무.Checked },
                    FUNC_5 = new SingleKeysInfo() { KEYS = keysTextBox기술_5_키.SelectedKeys, TIME_DELAY = delayTextBox기술_5_실행간격.ValueForInt, IS_MACROD_FUNC = checkBox기술_5_매크로유무.Checked },
                    FUNC_6 = new SingleKeysInfo() { KEYS = keysTextBox기술_6_키.SelectedKeys, TIME_DELAY = delayTextBox기술_6_실행간격.ValueForInt, IS_MACROD_FUNC = checkBox기술_6_매크로유무.Checked },
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

                keysTextBox기술_5_키.SelectedKeys = value.FUNC_4.KEYS;
                delayTextBox기술_5_실행간격.ValueForInt = value.FUNC_4.TIME_DELAY;
                checkBox기술_5_매크로유무.Checked = value.FUNC_4.IS_MACROD_FUNC;

                keysTextBox기술_6_키.SelectedKeys = value.FUNC_6.KEYS;
                delayTextBox기술_6_실행간격.ValueForInt = value.FUNC_6.TIME_DELAY;
                checkBox기술_6_매크로유무.Checked = value.FUNC_6.IS_MACROD_FUNC;
            }
        }

        #endregion 상단메뉴

        private void UpdateTitle()
        {
            string tempFileName = string.Empty;

            if(IS_NEW_FILE)
            {
                tempFileName = "NewFile";
            }
            else
            {
                tempFileName = System.IO.Path.GetFileNameWithoutExtension(OPENED_FILE_NAME);
            }

            if (IS_CHANGED)
                tempFileName = $"*{tempFileName}";

            this.Text = $"{tempFileName} - {PROGRAM_NAME}";
        }

        #region keysTextBox 공통 처리

        private void keysTextBox기술_1_키_KeysChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void keysTextBox기술_2_키_KeysChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void keysTextBox기술_3_키_KeysChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void keysTextBox기술_4_키_KeysChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void keysTextBox기술_5_키_KeysChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void keysTextBox기술_6_키_KeysChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        #endregion keysTextBox 공통 처리

        #region toolStripStatusLabel 공통 처리

        private void keysTextBox시작_키_Leave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = string.Empty;
        }

        private void keysTextBox종료_키_Leave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = string.Empty;
        }

        private void keysTextBox기술_1_키_Leave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = string.Empty;
        }

        private void keysTextBox기술_2_키_Leave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = string.Empty;
        }

        private void keysTextBox기술_3_키_Leave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = string.Empty;
        }

        private void keysTextBox기술_4_키_Leave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = string.Empty;
        }

        private void keysTextBox기술_5_키_Leave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = string.Empty;
        }

        private void keysTextBox기술_6_키_Leave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = string.Empty;
        }

        private void keysTextBox시작_키_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "키를 입력해 주세요.(ESC: 키 삭제)";
        }

        private void keysTextBox종료_키_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "키를 입력해 주세요.(ESC: 키 삭제)";
        }

        private void keysTextBox기술_1_키_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "키를 입력해 주세요.(ESC: 키 삭제)";
        }

        private void keysTextBox기술_2_키_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "키를 입력해 주세요.(ESC: 키 삭제)";
        }

        private void keysTextBox기술_3_키_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "키를 입력해 주세요.(ESC: 키 삭제)";
        }

        private void keysTextBox기술_4_키_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "키를 입력해 주세요.(ESC: 키 삭제)";
        }

        private void keysTextBox기술_5_키_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "키를 입력해 주세요.(ESC: 키 삭제)";
        }

        private void keysTextBox기술_6_키_Enter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "키를 입력해 주세요.(ESC: 키 삭제)";
        }

        #endregion toolStripStatusLabel 공통 처리
    }
}
