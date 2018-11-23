using MapleMacro2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleMacro2.Core
{
    public class HPMPWatcher
    {
        public const int TIMER_INTERVAL = 1000;

        public const string HP_MP_EMPTY_COLOR = "0x524D4F";
        //public const string HP_MP_EMPTY_COLOR = "0xA09D9E";        

        private int? PrevHPPercent;
        private int? PrevMPPercent;

        public int? CurrentHPPercent { get; private set; }
        public int? CurrentMPPercent { get; private set; }

        public event EventHandler HP_변경_시;
        public event EventHandler MP_변경_시;
        public event EventHandler Tick;

        private System.Timers.Timer timerMain = new System.Timers.Timer();

        public HPMPWatcher()
        {
            timerMain.Interval = TIMER_INTERVAL;
            timerMain.Elapsed += TimerMain_Elapsed;

            PrevHPPercent = 0;
            PrevMPPercent = 0;
        }

        public void Start()
        {
            if (timerMain.Enabled)
                return;

            timerMain.Enabled = true;
        }

        public void Stop()
        {
            if (timerMain.Enabled == false)
                return;

            timerMain.Enabled = false;
        }

        private void TimerMain_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // left header
            string img5 = $"{GlobalCode.PROGRAM_IMAGES_TEST}hpmp_left_original.bmp";
            var pointHeader = AutoHotkeyHelper.ImageSearch(588, 738, 608, 775, img5);
            
            // HP
            int? findHPPointX = null;
            int? findHPPercent = null;

            for (int i = 620; i <= 780; i = i + 20)
            {
                var color = AutoHotkeyHelper.PixelGetColor(i, 743);

                if (color == HP_MP_EMPTY_COLOR)
                {
                    findHPPointX = i;
                    break;
                }
            }

            if (findHPPointX.HasValue)
                findHPPercent = (int)(((double)(findHPPointX - 620) / (double)(780 - 620)) * 100);
            
            // MP             
            int? findMPPointX = null;
            int? findMPPercent = null;

            for (int i = 620; i <= 780; i = i + 20)
            {
                var color = AutoHotkeyHelper.PixelGetColor(i, 759);

                if (color == HP_MP_EMPTY_COLOR)
                {
                    findMPPointX = i;
                    break;
                }
            }

            if (findMPPointX.HasValue)
                findMPPercent = (int)(((double)(findMPPointX - 620) / (double)(780 - 620)) * 100);

            if (pointHeader.HasValue && !findHPPercent.HasValue)
                findHPPercent = 100;
            if (pointHeader.HasValue && !findMPPercent.HasValue)
                findMPPercent = 100;

            if (findHPPercent.HasValue)
            {
                CurrentHPPercent = findHPPercent;

                if (PrevHPPercent.HasValue && PrevHPPercent.Value != findHPPercent.Value)
                {
                    if (HP_변경_시 != null)
                        HP_변경_시(this, new EventArgs());
                }

                
                PrevHPPercent = findHPPercent;
            }

            if (findMPPercent.HasValue)
            {
                CurrentMPPercent = findMPPercent;

                if (PrevMPPercent.HasValue && PrevMPPercent.Value != findMPPercent.Value)
                {
                    if (MP_변경_시 != null)
                        MP_변경_시(this, new EventArgs());
                }
                
                PrevMPPercent = findMPPercent;
            }

        }
    }
}
