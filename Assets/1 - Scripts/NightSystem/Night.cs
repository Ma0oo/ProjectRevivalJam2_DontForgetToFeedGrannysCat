using System;
using System.Collections.Generic;
using DefaultNamespace.ApartmentSystem;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace DefaultNamespace.ScenesLogic.Game
{
    [CreateAssetMenu(menuName = "Game/Nights/Instance", order = 51)]
    public class Night : ScriptableObject
    {
        public Apartment Apartment;
        
        public IReadOnlyCollection<HourData> Hours => _hours;
        [SerializeField] private HourData[] _hours = new HourData[0];

        private void OnValidate()
        {
            if(_hours.Length<2) return;
            for (var i = 1; i < _hours.Length; i++)
            {
                _hours[i].Valid(_hours[i-1]);   
            }
        }

        [Button]private void SetDurationForAll(float Duration)
        {
            Duration = Duration <= 10 ? 10 : Duration;
            _hours.ForEach(x => x.DurationInSecond = Duration);
        }

        [System.Serializable]
        public class HourData
        {
            [Range(0, 23)]public int Hour;
            [UnityEngine.Min(0)] public float DurationInSecond = 180;
            public AnimationCurve SpeedByNormal = AnimationCurve.Linear(0,1,1,1);

            public void Valid(HourData preHourd)
            {
                if (preHourd.Hour == 23) Hour = 0;
                else Hour = preHourd.Hour + 1;
            }
        }
    }
}