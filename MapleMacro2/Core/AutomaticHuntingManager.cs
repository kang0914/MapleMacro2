using MapleMacro2.Data;
using MapleMacro2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleMacro2.Core
{
    public class AutomaticHuntingManager
    {
        bool 공격방향_오른쪽에서_왼쪽으로 = true;

        public Core.MiniMapWatcher miniMapWatcher = new Core.MiniMapWatcher();
        public Core.HPMPWatcher hPMPWatcher = new Core.HPMPWatcher();
        public System.Timers.Timer tmrMacro = new System.Timers.Timer();
        
        public MapleMacro2Config2 CurrentConfig { get; set; }

        public bool IsRunMacro { get; private set; }
        private Dictionary<System.Timers.Timer, SingleKeysInfo> listKeyTimer = new Dictionary<System.Timers.Timer, SingleKeysInfo>();

        #region Events

        public event EventHandler<string> OnLog;
        //public event EventHandler<>

        #endregion Events

        public AutomaticHuntingManager()
        {
            miniMapWatcher.화면_오른쪽에_도달_시 += MiniMapWatcher_화면_오른쪽에_도달_시;
            miniMapWatcher.화면_왼쪽에_도달_시 += MiniMapWatcher_화면_왼쪽에_도달_시;
            miniMapWatcher.룬_생성_시 += MiniMapWatcher_룬_생성_시;
            miniMapWatcher.다른_유저가_존재_시 += MiniMapWatcher_다른_유저가_존재_시;
            miniMapWatcher.히든_스트리트_생성_시 += MiniMapWatcher_히든_스트리트_생성_시;
            //miniMapWatcher.Tick += MiniMapWatcher_Tick;
            miniMapWatcher.Start();

            hPMPWatcher.HP_변경_시 += HPMPWatcher_HP_변경_시;
            hPMPWatcher.MP_변경_시 += HPMPWatcher_MP_변경_시;
            hPMPWatcher.Tick += HPMPWatcher_Tick;
            hPMPWatcher.Start();

            tmrMacro.Elapsed += TmrMacro_Elapsed;
        }

        public void Start()
        {
            if (tmrMacro.Enabled)
                return;

            IsRunMacro = true;

            Execute(CurrentConfig.FUNC_1);
            Execute(CurrentConfig.FUNC_2);
            Execute(CurrentConfig.FUNC_3);
            Execute(CurrentConfig.FUNC_4);
            Execute(CurrentConfig.FUNC_5);
            Execute(CurrentConfig.FUNC_6);

            tmrMacro.Interval = (int)CurrentConfig.TIMER_INTERVAL_PATTERN_1;
            tmrMacro.Enabled = true;
        }

        public void Stop()
        {
            if (tmrMacro.Enabled == false)
                return;

            IsRunMacro = false;

            tmrMacro.Enabled = false;

            foreach (var tmr in listKeyTimer)
            {
                tmr.Key.Stop();
                tmr.Key.Enabled = false;
                tmr.Key.Dispose();
            }
            listKeyTimer.Clear();
        }

        public void Toggle()
        {
            if (tmrMacro.Enabled)
                Stop();
            else
                Start();
        }

        private void Execute(SingleKeysInfo singleKeysInfo)
        {
            if (singleKeysInfo.KEYS == Keys.None || singleKeysInfo.TIME_DELAY == 0)
                return;

            // 최초 1회 실행
            AutoHotkeyHelper.Send(singleKeysInfo.KEYS);
            System.Threading.Thread.Sleep(60);

            // 타이머 설정
            System.Timers.Timer tmr = new System.Timers.Timer();

            tmr.Elapsed += (sender, e) =>
            {
                var tempTmr = sender as System.Timers.Timer;
                var tempSingleKeysInfo = listKeyTimer[tempTmr];

                AutoHotkeyHelper.Send(singleKeysInfo.KEYS);

                FireLog($"{tempSingleKeysInfo.KEYS.ToString()} 키 입력");
            };

            tmr.Interval = singleKeysInfo.TIME_DELAY;
            tmr.Enabled = true;

            listKeyTimer.Add(tmr, singleKeysInfo);
        }

        private void TmrMacro_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (공격방향_오른쪽에서_왼쪽으로)
            {
                //AutoHotkeyHelper.ExecRaw(CurrentConfig.SCRIPT_PATTERN_ATTACK_1);

                //FireLog("공격패턴 1 실행");
            }
            else
            {
                //AutoHotkeyHelper.ExecRaw(CurrentConfig.SCRIPT_PATTERN_ATTACK_2);
                
                //FireLog("공격패턴 2 실행");
            }
        }

        private void HPMPWatcher_Tick(object sender, EventArgs e)
        {
            if (CurrentConfig == null)
                return;
            if (CurrentConfig.USE_AUTO_POTION == false)
                return;
            if (CurrentConfig.KEYS_HP_POTION == Keys.None)
                return;

            if (hPMPWatcher.CurrentHPPercent < CurrentConfig.AUTO_POTION_HP_MIN)
            {
                AutoHotkeyHelper.Send(CurrentConfig.KEYS_HP_POTION);

                FireLog("HP 물약 사용");
            }

            if (hPMPWatcher.CurrentMPPercent < CurrentConfig.AUTO_POTION_MP_MIN)
            {
                AutoHotkeyHelper.Send(CurrentConfig.KEYS_MP_POTION);

                FireLog("MP 물약 사용");
            }
        }

        private void HPMPWatcher_HP_변경_시(object sender, EventArgs e)
        {
            if (CurrentConfig == null)
                return;
            if (CurrentConfig.USE_AUTO_POTION == false)
                return;
            if (CurrentConfig.KEYS_HP_POTION == Keys.None)
                return;

            //if (hPMPWatcher.CurrentHPPercent < CurrentConfig.AUTO_POTION_HP_MIN)
            //{ 
            //    AutoHotkeyHelper.Send(CurrentConfig.KEYS_HP_POTION);

            //    FireLog("HP 물약 사용");
            //}
        }

        private void HPMPWatcher_MP_변경_시(object sender, EventArgs e)
        {
            if (CurrentConfig == null)
                return;
            if (CurrentConfig.USE_AUTO_POTION == false)
                return;
            if (CurrentConfig.KEYS_MP_POTION == Keys.None)
                return;

            //if (hPMPWatcher.CurrentMPPercent < CurrentConfig.AUTO_POTION_MP_MIN)
            //{ 
            //    AutoHotkeyHelper.Send(CurrentConfig.KEYS_MP_POTION);

            //    FireLog("MP 물약 사용");
            //}
        }

        private void MiniMapWatcher_히든_스트리트_생성_시(object sender, EventArgs e)
        {
            FireLog("히든 스트리트가 생성됨.");
        }

        private void MiniMapWatcher_다른_유저가_존재_시(object sender, EventArgs e)
        {
            FireLog("다른 유저가 나타남.");
        }

        private void MiniMapWatcher_룬_생성_시(object sender, EventArgs e)
        {
            FireLog("룬이 생성됨.");
        }

        private void MiniMapWatcher_화면_왼쪽에_도달_시(object sender, EventArgs e)
        {
            FireLog("왼쪽에 도달");

            공격방향_오른쪽에서_왼쪽으로 = true;
        }

        private void MiniMapWatcher_화면_오른쪽에_도달_시(object sender, EventArgs e)
        {
            FireLog("오른쪽에 도달");

            공격방향_오른쪽에서_왼쪽으로 = false;
        }

        private void FireLog(string message)
        {
            if(OnLog != null)
                OnLog(this, message);
        }
    }
}
