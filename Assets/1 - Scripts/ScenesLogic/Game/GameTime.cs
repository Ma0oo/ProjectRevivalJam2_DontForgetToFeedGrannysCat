using System;
using System.Collections.Generic;
using System.Linq;
using NoSystem;
using Plugins.MaoUtility.SceneFlow;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace.ScenesLogic.Game
{
    public class GameTime : SceneLogic
    {
        private Night _night;

        [SerializeField] private int _currentIndex;
        [SerializeField] private float _currentDuration;
        private Night.HourData[] _hours;

        public float GlobalNormal => _currentIndex / (_hours.Length + 1) + NormalHours;

        public IReadOnlyCollection<Night.HourData> Hours => _hours;

        [ShowInInspector, Sirenix.OdinInspector.ReadOnly]
        public float NormalHours 
            => CurrentHours!=null ? _currentDuration / CurrentHours.DurationInSecond : 1;

        [ShowInInspector, Sirenix.OdinInspector.ReadOnly]
        public Night.HourData CurrentHours 
            => (_hours!=null && _hours.Length>0) ? _hours[Mathf.Clamp(_currentIndex, 0, _hours.Length)] : null;

        public event Action HourPass;

        public event Action NewNormal;

        public event Action AllHourPass;

        public void Init(Night night)
        {
            _night = night;
            _hours = night.Hours.ToArray().Clone() as Night.HourData[];
            StartHour(0);
        }

        private void Update()
        {
            if(_currentIndex>=_hours.Length) return;
            _currentDuration += Time.deltaTime * CurrentHours.SpeedByNormal.Evaluate(NormalHours);
            NewNormal?.Invoke();

            if (_currentDuration >= CurrentHours.DurationInSecond)
            {
                StartHour(_currentIndex+1);
                HourPass?.Invoke();
            }
        }

        private void StartHour(int hourIndex)
        {
            _currentIndex = hourIndex;
            _currentIndex = Mathf.Clamp(_currentIndex, 0, _hours.Length-1);
            _currentDuration = 0;
            if (_currentIndex >= _hours.Length - 1)
            {
                AllHourPass?.Invoke();
                enabled = false;
            }
        }
    }
}