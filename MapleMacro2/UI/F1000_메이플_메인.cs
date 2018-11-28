using MapleMacro2.Core;
using MapleMacro2.Data;
using MapleMacro2.UI;
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
    public partial class F1000 : Form
    {
        AutomaticHuntingManager automaticHuntingManager = new AutomaticHuntingManager();

        public F1000()
        {
            InitializeComponent();

            IS_NEW_FILE = true;
        }

        private void F1000_Load(object sender, EventArgs e)
        {
            var defaultConfig = new MapleMacro2Config2();
            CurrentConfig = defaultConfig;

            if (Properties.Settings.Default.RECENTLY_OPENED_FILES == null)
                Properties.Settings.Default.RECENTLY_OPENED_FILES = new System.Collections.Specialized.StringCollection();

            // 마지막 설정 파일 열기
            LoadConfigFile(Properties.Settings.Default.LAST_OPENED_FILE);

            UpdateTitle();

            UpdateRecentlyOpenConfigFile();

            automaticHuntingManager.OnLog += AutomaticHuntingManager_OnLog;

            toolStripStatusLabelFileVersion.Text = "v" + System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;
        }

        private void timer미니맵_Tick(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                // minimap_title
                if (automaticHuntingManager.miniMapWatcher.CourrentPointMinimapTitle.HasValue)
                    labelImageSearch.Text = $"X:{automaticHuntingManager.miniMapWatcher.CourrentPointMinimapTitle.Value.X}, Y:{automaticHuntingManager.miniMapWatcher.CourrentPointMinimapTitle.Value.Y}";
                else
                    labelImageSearch.Text = "";

                // minimap_right
                if (automaticHuntingManager.miniMapWatcher.CourrentPointRight.HasValue)
                    labelRight.Text = $"X:{automaticHuntingManager.miniMapWatcher.CourrentPointRight.Value.X}, Y:{automaticHuntingManager.miniMapWatcher.CourrentPointRight.Value.Y}";
                else
                    labelRight.Text = "";

                // minimap_left
                if (automaticHuntingManager.miniMapWatcher.CourrentPointLeft.HasValue)
                    labelLeft.Text = $"X:{automaticHuntingManager.miniMapWatcher.CourrentPointLeft.Value.X}, Y:{automaticHuntingManager.miniMapWatcher.CourrentPointLeft.Value.Y}";
                else
                    labelLeft.Text = "";

                // minimap_user
                if (automaticHuntingManager.miniMapWatcher.CourrentPointUser.HasValue)
                    labelUser.Text = $"X:{automaticHuntingManager.miniMapWatcher.CourrentPointUser.Value.X}, Y:{automaticHuntingManager.miniMapWatcher.CourrentPointUser.Value.Y}";
                else
                    labelUser.Text = "";

                // minimap rune
                if (automaticHuntingManager.miniMapWatcher.CourrentPointRune.HasValue)
                    labelRune.Text = $"X:{automaticHuntingManager.miniMapWatcher.CourrentPointRune.Value.X}, Y:{automaticHuntingManager.miniMapWatcher.CourrentPointRune.Value.Y}";
                else
                    labelRune.Text = "";

                // minimap hidden street
                if (automaticHuntingManager.miniMapWatcher.CourrentPointHiddenStreet.HasValue)
                    labelHiddenStreet.Text = $"X:{automaticHuntingManager.miniMapWatcher.CourrentPointHiddenStreet.Value.X}, Y:{automaticHuntingManager.miniMapWatcher.CourrentPointHiddenStreet.Value.Y}";
                else
                    labelHiddenStreet.Text = "";

                // minimap diff user
                if (automaticHuntingManager.miniMapWatcher.CourrentPointDiffUser.HasValue)
                    labelDiffUser.Text = $"X:{automaticHuntingManager.miniMapWatcher.CourrentPointDiffUser.Value.X}, Y:{automaticHuntingManager.miniMapWatcher.CourrentPointDiffUser.Value.Y}";
                else
                    labelDiffUser.Text = "";

                // HP/MP
                labelPixelSearchHP.Text = automaticHuntingManager.hPMPWatcher.CurrentHPPercent.ToString();
                labelPixelSearch.Text = automaticHuntingManager.hPMPWatcher.CurrentMPPercent.ToString();
            }));
        }

        private void AutomaticHuntingManager_OnLog(object sender, string e)
        {
            AddLog(e);
        }

        private void AddLog(string message)
        {
            Invoke(new Action(() =>
            {
                textBoxLog.Text += string.Format("[{0}] {1}\r\n", DateTime.Now.ToString("HH:mm:ss"), message);
                textBoxLog.SelectionStart = textBoxLog.Text.Length;
                textBoxLog.ScrollToCaret();
            }));
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

        private void F1000_FormClosing(object sender, FormClosingEventArgs e)
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
                    var readConfig = XMLHelper.ReadFromXmlFile<MapleMacro2Config2>(lastConfigFile);

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

        private void StartMacro()
        {
            if (automaticHuntingManager.IsRunMacro)
                return;

            automaticHuntingManager.CurrentConfig = CurrentConfig;
            automaticHuntingManager.Start();

            toolStripProgressBar시작유무.Value = 100;
            toolStripStatusLabel시작유무.Text = "동작 중...";
                        
            toolStripButton새파일.Enabled = false;
            toolStripButton열기.Enabled = false;
            toolStripButton저장.Enabled = false;
            toolStripButton시작.Enabled = false;
            toolStripButton중지.Enabled = true;
            toolStripButton정보.Enabled = false;

            panel루트.Enabled = false;

            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipText = "매크로가 시작되었습니다.";
            notifyIcon1.ShowBalloonTip(500);
        }

        private void EndMacro()
        {
            if (automaticHuntingManager.IsRunMacro == false)
                return;

            //IsRunMacro = false;

            //foreach (var tmr in listKeyTimer)
            //{
            //    tmr.Stop();
            //    tmr.Enabled = false;
            //    tmr.Dispose();
            //}
            //listKeyTimer.Clear();

            automaticHuntingManager.Stop();

            toolStripProgressBar시작유무.Value = 0;
            toolStripStatusLabel시작유무.Text = "정지";

            toolStripButton새파일.Enabled = true;
            toolStripButton열기.Enabled = true;
            toolStripButton저장.Enabled = true;
            toolStripButton시작.Enabled = true;
            toolStripButton중지.Enabled = false;
            toolStripButton정보.Enabled = true;

            panel루트.Enabled = true;

            notifyIcon1.BalloonTipText = "매크로가 종료되었습니다.";
            notifyIcon1.ShowBalloonTip(500);
        }

        private void ToggleMacro()
        {
            if (automaticHuntingManager.IsRunMacro)
                EndMacro();
            else
                StartMacro();
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

            IS_CHANGED = true;
        }

        private void keysTextBox종료_키_KeysChanged(object sender, EventArgs e)
        {
            UpdateHotKey();

            IS_CHANGED = true;
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

        private void 옵션ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F9000 form = new F9000();

            form.ShowDialog();
        }

        // 새 파일
        private void CreateNewFile()
        {
            IS_NEW_FILE = true;

            CurrentConfig = new MapleMacro2Config2();

            IS_CHANGED = true;

            UpdateTitle();
        }

        // 열기
        private void OpenConfigFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Maple Macro2 Config File (*.mm2proj)|*.mm2proj";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var readConfig = XMLHelper.ReadFromXmlFile<MapleMacro2Config2>(ofd.FileName);

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
                    XMLHelper.WriteToXmlFile<MapleMacro2Config2>(OPENED_FILE_NAME, CurrentConfig);

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

            sfd.Filter = "Macro Story Config File (*.mm2proj)|*.mm2proj";
            sfd.FileName = "제목없음";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                XMLHelper.WriteToXmlFile<MapleMacro2Config2>(sfd.FileName, CurrentConfig);
                
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

        private MapleMacro2Config2 CurrentConfig
        {
            get
            {
                return new MapleMacro2Config2()
                {
                    KEYS_MACRO_START = keysTextBox시작_키.SelectedKeys,
                    KEYS_MACRO_END = keysTextBox종료_키.SelectedKeys,

                    USE_AUTO_BUFF = checkBox자동버프_기능_사용.Checked,
                    USE_AUTO_POTION = checkBox자동물약_기능_사용.Checked,
                    USE_AUTO_HUNTING = checkBox자동사냥_기능_사용.Checked,

                    KEYS_HP_POTION = keysTextBox자동물약_HP.SelectedKeys,
                    KEYS_MP_POTION = keysTextBox자동물약_MP.SelectedKeys,
                    AUTO_POTION_HP_MIN = (int)numericUpDown자동물약_HP_최소.Value,
                    AUTO_POTION_MP_MIN = (int)numericUpDown자동물약_MP_최소.Value,

                    FUNC_1 = new SingleKeysInfo() { KEYS = keysTextBox기술_1_키.SelectedKeys, TIME_DELAY = delayTextBox기술_1_실행간격.ValueForInt },
                    FUNC_2 = new SingleKeysInfo() { KEYS = keysTextBox기술_2_키.SelectedKeys, TIME_DELAY = delayTextBox기술_2_실행간격.ValueForInt },
                    FUNC_3 = new SingleKeysInfo() { KEYS = keysTextBox기술_3_키.SelectedKeys, TIME_DELAY = delayTextBox기술_3_실행간격.ValueForInt },
                    FUNC_4 = new SingleKeysInfo() { KEYS = keysTextBox기술_4_키.SelectedKeys, TIME_DELAY = delayTextBox기술_4_실행간격.ValueForInt },
                    FUNC_5 = new SingleKeysInfo() { KEYS = keysTextBox기술_5_키.SelectedKeys, TIME_DELAY = delayTextBox기술_5_실행간격.ValueForInt },
                    FUNC_6 = new SingleKeysInfo() { KEYS = keysTextBox기술_6_키.SelectedKeys, TIME_DELAY = delayTextBox기술_6_실행간격.ValueForInt },

                    TIMER_INTERVAL_PATTERN_1 = (int)numericUpDownMacroInterval.Value,

                    SCRIPT_PATTERN_ATTACK_1 = textBox공격패턴_1.Text,
                    SCRIPT_PATTERN_ATTACK_2 = textBox공격패턴_2.Text,
                };
            }

            set
            {

                keysTextBox시작_키.SelectedKeys = value.KEYS_MACRO_START;
                keysTextBox종료_키.SelectedKeys = value.KEYS_MACRO_END;

                checkBox자동버프_기능_사용.Checked = value.USE_AUTO_BUFF;
                checkBox자동물약_기능_사용.Checked = value.USE_AUTO_POTION;
                checkBox자동사냥_기능_사용.Checked = value.USE_AUTO_HUNTING;

                keysTextBox기술_1_키.SelectedKeys = value.FUNC_1.KEYS;
                delayTextBox기술_1_실행간격.ValueForInt = value.FUNC_1.TIME_DELAY;
                
                keysTextBox기술_2_키.SelectedKeys = value.FUNC_2.KEYS;
                delayTextBox기술_2_실행간격.ValueForInt = value.FUNC_2.TIME_DELAY;

                keysTextBox기술_3_키.SelectedKeys = value.FUNC_3.KEYS;
                delayTextBox기술_3_실행간격.ValueForInt = value.FUNC_3.TIME_DELAY;

                keysTextBox기술_4_키.SelectedKeys = value.FUNC_4.KEYS;
                delayTextBox기술_4_실행간격.ValueForInt = value.FUNC_4.TIME_DELAY;

                keysTextBox기술_5_키.SelectedKeys = value.FUNC_5.KEYS;
                delayTextBox기술_5_실행간격.ValueForInt = value.FUNC_5.TIME_DELAY;

                keysTextBox기술_6_키.SelectedKeys = value.FUNC_6.KEYS;
                delayTextBox기술_6_실행간격.ValueForInt = value.FUNC_6.TIME_DELAY;

                numericUpDownMacroInterval.Value = value.TIMER_INTERVAL_PATTERN_1;

                textBox공격패턴_1.Text = value.SCRIPT_PATTERN_ATTACK_1;
                textBox공격패턴_2.Text = value.SCRIPT_PATTERN_ATTACK_2;

                keysTextBox자동물약_HP.SelectedKeys = value.KEYS_HP_POTION;
                keysTextBox자동물약_MP.SelectedKeys = value.KEYS_MP_POTION;
                numericUpDown자동물약_HP_최소.Value = value.AUTO_POTION_HP_MIN;
                numericUpDown자동물약_MP_최소.Value = value.AUTO_POTION_MP_MIN;
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

            this.Text = $"{tempFileName} - {GlobalCode.PROGRAM_NAME}";
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

        private void toolStripButton시작_Click(object sender, EventArgs e)
        {
            StartMacro();
        }

        private void toolStripButton중지_Click(object sender, EventArgs e)
        {
            EndMacro();
        }

        private void delayTextBox기술_1_실행간격_ValueChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void delayTextBox기술_2_실행간격_ValueChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void delayTextBox기술_3_실행간격_ValueChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void delayTextBox기술_4_실행간격_ValueChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void delayTextBox기술_5_실행간격_ValueChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void delayTextBox기술_6_실행간격_ValueChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void checkBox자동버프_기능_사용_CheckedChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void checkBox자동물약_기능_사용_CheckedChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void checkBox자동사냥_기능_사용_CheckedChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void keysTextBox자동물약_HP_KeysChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void keysTextBox자동물약_MP_KeysChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void numericUpDown자동물약_HP_최소_ValueChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void numericUpDown자동물약_MP_최소_ValueChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void numericUpDownMacroInterval_ValueChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void textBox공격패턴_1_TextChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }

        private void textBox공격패턴_2_TextChanged(object sender, EventArgs e)
        {
            IS_CHANGED = true;
        }
    }
}
