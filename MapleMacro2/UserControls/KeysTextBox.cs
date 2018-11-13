using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapleMacro2.UserControls
{
    public class KeysTextBox : TextBox
    {
        public event EventHandler KeysChanged;

        public KeysTextBox() :
            base()
        {
            ReadOnly = true;
        }

        private Keys _SelectedKeys;
        public Keys SelectedKeys
        {
            get { return _SelectedKeys; }
            set
            {
                _SelectedKeys = value;

                UpdateDisplayText();

                if (KeysChanged != null)
                    KeysChanged(this, new EventArgs());
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                SelectedKeys = Keys.None;
                e.Handled = true;
            }
            else
            {
                SelectedKeys = e.KeyData;
                e.Handled = true;
            }

            base.OnKeyDown(e);
        }

        private void UpdateDisplayText()
        {
            Text = Utils.KeysHelper.KeysToPrettyPrint(SelectedKeys);
        }
    }
}
