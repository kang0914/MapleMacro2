using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapleMacro2.Data
{
    public class MapleMacro2Config2
    {
        public Keys KEYS_MACRO_START { get; set; }
        public Keys KEYS_MACRO_END { get; set; }

        public bool USE_AUTO_POTION { get; set; }
        public bool USE_AUTO_BUFF { get; set; }
        public bool USE_AUTO_HUNTING { get; set; }

        public Keys KEYS_HP_POTION { get; set; }
        public Keys KEYS_MP_POTION { get; set; }        
        public int AUTO_POTION_HP_MIN { get; set; }
        public int AUTO_POTION_MP_MIN { get; set; }
        
        public SingleKeysInfo FUNC_1 { get; set; }
        public SingleKeysInfo FUNC_2 { get; set; }
        public SingleKeysInfo FUNC_3 { get; set; }
        public SingleKeysInfo FUNC_4 { get; set; }
        public SingleKeysInfo FUNC_5 { get; set; }
        public SingleKeysInfo FUNC_6 { get; set; }
        
        public int TIMER_INTERVAL_PATTERN_1 { get; set; }

        public string SCRIPT_PATTERN_ATTACK_1 { get; set; }
        public string SCRIPT_PATTERN_ATTACK_2 { get; set; }

        public MapleMacro2Config2()
        {
            USE_AUTO_POTION = false;
            USE_AUTO_BUFF = true;
            USE_AUTO_HUNTING = false;

            AUTO_POTION_HP_MIN = 50;
            AUTO_POTION_MP_MIN = 50;
            
            FUNC_1 = new SingleKeysInfo();
            FUNC_2 = new SingleKeysInfo();
            FUNC_3 = new SingleKeysInfo();
            FUNC_4 = new SingleKeysInfo();
            FUNC_5 = new SingleKeysInfo();
            FUNC_6 = new SingleKeysInfo();

            TIMER_INTERVAL_PATTERN_1 = 2000;
        }
    }
}
