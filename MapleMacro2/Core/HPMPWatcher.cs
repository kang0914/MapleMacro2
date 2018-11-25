using MapleMacro2.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleMacro2.Core
{
    public class HPMPWatcher
    {
        public const int TIMER_INTERVAL = 1000;

        private int? PrevHPPercent;
        private int? PrevMPPercent;

        public int? CurrentHPPercent { get; private set; }
        public int? CurrentMPPercent { get; private set; }

        public event EventHandler HP_변경_시;
        public event EventHandler MP_변경_시;
        public event EventHandler Tick;

        private System.Timers.Timer timerMain = new System.Timers.Timer();

        HP_MP_BAR_POSITION_INFO RESOLUTION_1366_768 = new HP_MP_BAR_POSITION_INFO();
        HP_MP_BAR_POSITION_INFO RESOLUTION_800_600 = new HP_MP_BAR_POSITION_INFO();

        public HPMPWatcher()
        {
            timerMain.Interval = TIMER_INTERVAL;
            timerMain.Elapsed += TimerMain_Elapsed;

            PrevHPPercent = 0;
            PrevMPPercent = 0;

            RESOLUTION_800_600.HEADER_LEFT_TOP = new Point(415, 575);
            RESOLUTION_800_600.HEADER_RIGHT_BOTTOM = new Point(433, 604);
            RESOLUTION_800_600.HPMP_MIN_X = 440;
            RESOLUTION_800_600.HPMP_MAX_X = 575;
            RESOLUTION_800_600.HP_CHECK_Y = 575;
            RESOLUTION_800_600.MP_CHECK_Y = 591;
            RESOLUTION_800_600.HP_EMPTY_COLOR = "0x484345";
            RESOLUTION_800_600.MP_EMPTY_COLOR = "0x4E484A";

            RESOLUTION_1366_768.HEADER_LEFT_TOP = new Point(588, 738);
            RESOLUTION_1366_768.HEADER_RIGHT_BOTTOM = new Point(608, 775);
            RESOLUTION_1366_768.HPMP_MIN_X = 620;
            RESOLUTION_1366_768.HPMP_MAX_X = 780;
            RESOLUTION_1366_768.HP_CHECK_Y = 743;
            RESOLUTION_1366_768.MP_CHECK_Y = 759;
            RESOLUTION_1366_768.HP_EMPTY_COLOR = "0x524D4F";
            RESOLUTION_1366_768.MP_EMPTY_COLOR = "0x524D4F";
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

        private HP_MP_BAR_POSITION_INFO GetCurrentResolution()
        {
            var size = SendMessageHelper.GetWindowRect("MapleStory");

            if (size.HasValue == false)
                return null;

            HP_MP_BAR_POSITION_INFO temp = null;

            if (size.Value.Width == 806 && size.Value.Height == 629)
                temp = RESOLUTION_800_600;
            else if (size.Value.Width == 1030 && size.Value.Height == 797)
                temp = null;
            else if (size.Value.Width == 1286 && size.Value.Height == 749)
                temp = null;
            else if (size.Value.Width == 1372 && size.Value.Height == 797)
                temp = RESOLUTION_1366_768;
            else if (size.Value.Width == 1926 && size.Value.Height == 1089)
                temp = null;
            else
                temp = null;

            return temp;
        }

        private void TimerMain_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var CurrentResolution = GetCurrentResolution();

            if (CurrentResolution == null)
            {
                CurrentHPPercent = null;
                CurrentMPPercent = null;
                return;
            }

            // left header
            string img5 = $"{GlobalCode.PROGRAM_IMAGES_TEST}hpmp_left_original.bmp";
            var pointHeader = AutoHotkeyHelper.ImageSearch(CurrentResolution.HEADER_LEFT_TOP.X, CurrentResolution.HEADER_LEFT_TOP.Y, CurrentResolution.HEADER_RIGHT_BOTTOM.X, CurrentResolution.HEADER_RIGHT_BOTTOM.Y, img5);
            
            if(pointHeader.HasValue == false)
            {
                CurrentHPPercent = null;
                CurrentMPPercent = null;
                return;
            }

            // HP
            int? findHPPointX = null;
            int? findHPPercent = null;

            for (int i = CurrentResolution.HPMP_MIN_X; i <= CurrentResolution.HPMP_MAX_X; i = i + 20)
            {
                var color = AutoHotkeyHelper.PixelGetColor(i, CurrentResolution.HP_CHECK_Y);

                if (color == CurrentResolution.HP_EMPTY_COLOR)
                {
                    findHPPointX = i;
                    break;
                }
            }

            if (findHPPointX.HasValue)
                findHPPercent = (int)(((double)(findHPPointX - CurrentResolution.HPMP_MIN_X) / (double)(CurrentResolution.HPMP_MAX_X - CurrentResolution.HPMP_MIN_X)) * 100);
            
            // MP             
            int? findMPPointX = null;
            int? findMPPercent = null;

            for (int i = CurrentResolution.HPMP_MIN_X; i <= CurrentResolution.HPMP_MAX_X; i = i + 20)
            {
                var color = AutoHotkeyHelper.PixelGetColor(i, CurrentResolution.MP_CHECK_Y);

                if (color == CurrentResolution.MP_EMPTY_COLOR)
                {
                    findMPPointX = i;
                    break;
                }
            }

            if (findMPPointX.HasValue)
                findMPPercent = (int)(((double)(findMPPointX - CurrentResolution.HPMP_MIN_X) / (double)(CurrentResolution.HPMP_MAX_X - CurrentResolution.HPMP_MIN_X)) * 100);

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

            if (Tick != null)
                Tick(this, new EventArgs());
        }

        public class HP_MP_BAR_POSITION_INFO
        {
            public Point HEADER_LEFT_TOP;
            public Point HEADER_RIGHT_BOTTOM;

            public int HPMP_MIN_X;
            public int HPMP_MAX_X;

            public int HP_CHECK_Y;
            public int MP_CHECK_Y;

            public string HP_EMPTY_COLOR;
            public string MP_EMPTY_COLOR;
        }
    }
}
