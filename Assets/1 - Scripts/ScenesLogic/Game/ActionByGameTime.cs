using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace.ScenesLogic.Game
{
    [System.Serializable]
    public class ActionByGameTime
    {
        private Action _callback;
        [ShowInInspector]public int TargetHour { get; private set; }
        [ShowInInspector]public int Minute{ get; private set; }

        public ActionByGameTime(int hour, int minute, Action callback)
        {
            TargetHour = Mathf.Clamp(hour, 0, 24);
            Minute = Mathf.Clamp(minute, 0, 60);
            _callback = callback;
        }

        public void Evnting() => _callback();

        public bool TryAct(int hour, float normalHour)
        {
            if (hour != TargetHour) return false;
            return normalHour > (Minute / 60f);
        }
    }
}