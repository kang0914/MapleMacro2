using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapleMacro2.Data
{
    public class MapleMacro2Config
    {
        public Keys KEYS_MACRO_START { get; set; }
        public Keys KEYS_MACRO_END { get; set; }

        public int TIME_MACRO_FUNC_ON { get; set; }

        public SingleKeysInfo FUNC_1 { get; set; }
        public SingleKeysInfo FUNC_2 { get; set; }
        public SingleKeysInfo FUNC_3 { get; set; }
        public SingleKeysInfo FUNC_4 { get; set; }

        public MapleMacro2Config()
        {
            FUNC_1 = new SingleKeysInfo();
            FUNC_2 = new SingleKeysInfo();
            FUNC_3 = new SingleKeysInfo();
            FUNC_4 = new SingleKeysInfo();
        }
    }
}
