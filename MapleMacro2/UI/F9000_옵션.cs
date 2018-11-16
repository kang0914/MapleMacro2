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
    public partial class F9000 : Form
    {
        public F9000()
        {
            InitializeComponent();
        }

        private void F9000_Load(object sender, EventArgs e)
        {
            switch(Properties.Settings.Default.SELECTED_GAME_TITLE)
            {
                case GlobalCode.PROGRAM_TITLE_MAPLESTORY:
                    radioButton게임_설정_메이플스토리.Checked = true;
                    break;
                case GlobalCode.PROGRAM_TITLE_DIABLO3:
                    radioButton게임_설정_디아블로3.Checked = true;
                    break;
                default:
                    radioButton게임_설정_직접_입력.Checked = true;
                    radioButton게임_설정_직접_입력.Text = Properties.Settings.Default.SELECTED_GAME_TITLE;
                    break;
            }
        }

        private void radioButton게임_설정_직접_입력_CheckedChanged(object sender, EventArgs e)
        {
            textBox게임_설정_직접_입력.Enabled = radioButton게임_설정_직접_입력.Checked;
        }

        private void button확인_Click(object sender, EventArgs e)
        {
            if (radioButton게임_설정_메이플스토리.Checked)
                Properties.Settings.Default.SELECTED_GAME_TITLE = GlobalCode.PROGRAM_TITLE_MAPLESTORY;
            if (radioButton게임_설정_디아블로3.Checked)
                Properties.Settings.Default.SELECTED_GAME_TITLE = GlobalCode.PROGRAM_TITLE_DIABLO3;
            if (radioButton게임_설정_직접_입력.Checked)
                Properties.Settings.Default.SELECTED_GAME_TITLE = radioButton게임_설정_직접_입력.Text;

            Properties.Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
        }

        private void button취소_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
