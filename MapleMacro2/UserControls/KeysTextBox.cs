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
            ShortcutsEnabled = false;
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
            if (e.KeyCode == Keys.Escape)
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
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (Focused)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (IsFirstClick)
                    { 
                        IsFirstClick = false;
                    }
                    else
                        SelectedKeys = Keys.LButton;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    SelectedKeys = Keys.RButton;
                }
                else if (e.Button == MouseButtons.Middle)
                {
                    SelectedKeys = Keys.MButton;
                }
            }

            base.OnMouseDown(e);
        }

        private bool IsFirstClick;
        protected override void OnGotFocus(EventArgs e)
        {
            IsFirstClick = true;

            base.OnGotFocus(e);
        }

        private void UpdateDisplayText()
        {
            Text = Utils.KeysHelper.KeysToPrettyPrint(SelectedKeys);
        }
    }
}
