﻿using MapleMacro2.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleMacro2.Core
{
    public class MiniMapWatcher
    {
        public Point POINT_MINIMAP_LEFT_TOP = new Point(0, 25);
        public Point POINT_MINIMAP_RIGHT_BOTTOM = new Point(500, 500);

        public const int TIMER_INTERVAL = 1000;

        private Point? PrevPointMinimapTitle = null;
        private Point? PrevPointUser = null;
        private Point? PrevPointRune = null;
        private Point? PrevPointHiddenStreet = null;
        private Point? PrevPointDiffUser = null;

        public Point? CourrentPointMinimapTitle { get; private set; }
        public Point? CourrentPointRight { get; private set; }
        public Point? CourrentPointLeft { get; private set; }
        public Point? CourrentPointUser { get; private set; }        
        public Point? CourrentPointRune { get; private set; }
        public Point? CourrentPointHiddenStreet { get; private set; }
        public Point? CourrentPointDiffUser { get; private set; }

        public event EventHandler 화면_왼쪽에_도달_시;
        public event EventHandler 화면_오른쪽에_도달_시;
        public event EventHandler 룬_생성_시;
        public event EventHandler 히든_스트리트_생성_시;
        public event EventHandler 다른_유저가_존재_시;

        public event EventHandler Tick;

        private System.Timers.Timer timerMain = new System.Timers.Timer();

        public MiniMapWatcher()
        {
            timerMain.Interval = TIMER_INTERVAL;
            timerMain.Elapsed += TimerMain_Elapsed;
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
            // minimap_title
            string img5 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_transblack.bmp";
            var pointMinimapTitle = AutoHotkeyHelper.ImageSearch(POINT_MINIMAP_LEFT_TOP.X, POINT_MINIMAP_LEFT_TOP.Y, 550, 150, img5);

            CourrentPointMinimapTitle = pointMinimapTitle;

            // minimap_right
            string img13 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_right_transblack.bmp";
            var pointRight = AutoHotkeyHelper.ImageSearch(POINT_MINIMAP_LEFT_TOP.X, POINT_MINIMAP_LEFT_TOP.Y, 500, 300, img13);

            CourrentPointRight = pointRight;

            // minimap_left
            string img14 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_left_transblack.bmp";
            var pointLeft = AutoHotkeyHelper.ImageSearch(POINT_MINIMAP_LEFT_TOP.X, POINT_MINIMAP_LEFT_TOP.Y, 300, 500, img14);

            CourrentPointLeft = pointLeft;

            if (CourrentPointMinimapTitle.HasValue == false ||
                CourrentPointRight.HasValue == false)
            {
                CourrentPointMinimapTitle = null;
                CourrentPointRight = null;
                CourrentPointLeft = null;
                CourrentPointUser = null;
                CourrentPointRune = null;
                CourrentPointHiddenStreet = null;
                CourrentPointDiffUser = null;

                return;
            }

            // minimap_user
            string img12 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_user_transblack3.bmp";
            var pointUser = AutoHotkeyHelper.ImageSearch(POINT_MINIMAP_LEFT_TOP.X, POINT_MINIMAP_LEFT_TOP.Y, Math.Min(POINT_MINIMAP_RIGHT_BOTTOM.X, pointRight.Value.X), POINT_MINIMAP_RIGHT_BOTTOM.Y, img12);

            CourrentPointUser = pointUser;

            // minimap rune
            string img15 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_rune_transblack.bmp";
            var pointRune = AutoHotkeyHelper.ImageSearch(POINT_MINIMAP_LEFT_TOP.X, POINT_MINIMAP_LEFT_TOP.Y, Math.Min(POINT_MINIMAP_RIGHT_BOTTOM.X, pointRight.Value.X), POINT_MINIMAP_RIGHT_BOTTOM.Y, img15);

            CourrentPointRune = pointRune;

            // minimap hidden street
            string img16 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_hiddenstreet_transblack.bmp";
            var pointHiddenStreet = AutoHotkeyHelper.ImageSearch(POINT_MINIMAP_LEFT_TOP.X, POINT_MINIMAP_LEFT_TOP.Y, Math.Min(POINT_MINIMAP_RIGHT_BOTTOM.X, pointRight.Value.X), POINT_MINIMAP_RIGHT_BOTTOM.Y, img16);

            CourrentPointHiddenStreet = pointHiddenStreet;

            // minimap diff user
            string img17 = $"{GlobalCode.PROGRAM_IMAGES_TEST}minimap_diff_user_transblack.bmp";
            var pointDiffUser = AutoHotkeyHelper.ImageSearch(POINT_MINIMAP_LEFT_TOP.X, POINT_MINIMAP_LEFT_TOP.Y, Math.Min(POINT_MINIMAP_RIGHT_BOTTOM.X, pointRight.Value.X), POINT_MINIMAP_RIGHT_BOTTOM.Y, img17);

            CourrentPointDiffUser = pointDiffUser;

            // 왼쪽/오른쪽 방향 바꾸기
            if (pointUser.HasValue && pointLeft.HasValue && 
                pointUser.Value.X < (pointLeft.Value.X + 30))
            {
                if (화면_왼쪽에_도달_시 != null)
                    화면_왼쪽에_도달_시(this, new EventArgs());
            }

            if (pointUser.HasValue && pointRight.HasValue && 
                pointUser.Value.X > (pointRight.Value.X - 30))
            {
                if (화면_오른쪽에_도달_시 != null)
                    화면_오른쪽에_도달_시(this, new EventArgs());
            }

            if (pointMinimapTitle.HasValue && (PrevPointRune.HasValue == false) && pointRune.HasValue)
            {
                if (룬_생성_시 != null)
                    룬_생성_시(this, new EventArgs());
            }

            if (pointMinimapTitle.HasValue && (PrevPointHiddenStreet.HasValue == false) && pointHiddenStreet.HasValue)
            {
                if (히든_스트리트_생성_시 != null)
                    히든_스트리트_생성_시(this, new EventArgs());
            }

            if (pointMinimapTitle.HasValue && (PrevPointDiffUser.HasValue == false) && pointDiffUser.HasValue)
            {
                if (다른_유저가_존재_시 != null)
                    다른_유저가_존재_시(this, new EventArgs());
            }

            PrevPointMinimapTitle = pointMinimapTitle;
            PrevPointUser = pointUser;
            PrevPointRune = pointRune;
            PrevPointHiddenStreet = pointHiddenStreet;
            PrevPointDiffUser = pointDiffUser;

            if (Tick != null)
                Tick(this, new EventArgs());
        }
    }
}
