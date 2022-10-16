using System.Linq;
using DefaultNamespace.ScenesLogic.Game;
using UnityEngine;

namespace DataGame.Keys
{
    public class ViewGameTimeClock : BaseViewGameTime
    {
        [SerializeField] private Transform _hourArrow;
        [SerializeField] private Transform _minuteArrow;
        [SerializeField] private Transform _targetArrow;
        [SerializeField] private TimeType _time;
        private float _hourAngel;
        private float _baseAngel;

        protected override void CustomStart()
        {
            _targetArrow.localEulerAngles = new Vector3(0, 0, GetAngelHour(Time.Hours.Last()));
        }

        protected override void OnNewNormal(float normal)
        {
            _minuteArrow.localEulerAngles = new Vector3(0,0, Mathf.Lerp(0, -360, normal));
            _hourArrow.localEulerAngles = new Vector3(0,0, _hourAngel+_baseAngel*normal);
        }

        protected override void OnNewHours(Night.HourData hour) => _hourAngel = GetAngelHour(hour);

        private float GetAngelHour(Night.HourData hourd)
        {
            _baseAngel = GetBaseAngelHour();
            if (_time == TimeType.T24)
                return hourd.Hour * _baseAngel;
            else
                return (hourd.Hour >= 12 ? hourd.Hour - 12 : hourd.Hour) * _baseAngel;
        }
        
        private float GetBaseAngelHour() => _time == TimeType.T24 ? -360 / 24 : -360 / 12;

        public enum TimeType { T24, T12 }
    }
}