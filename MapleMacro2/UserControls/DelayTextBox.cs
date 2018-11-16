using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapleMacro2.UserControls
{
    public class DelayTextBox : System.Windows.Forms.NumericUpDown
    {
        public int ValueForInt
        {
            get { return (int)this.Value; }
            set { this.Value = value; }
        }

        public DelayTextBox()
        {
            //Controls[0].Visible = false;
        }
    }
}
