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

        protected override void CustomStart() => _targetArrow.eulerAngles=new Vector3(0,0, GetAngelHour(Time.Hours.Last()));

        protected override void OnNewNormal(float normal)
        {
            _minuteArrow.eulerAngles = new Vector3(0,0, Mathf.Lerp(-360, 0, normal));
            _hourArrow.eulerAngles = new Vector3(0,0, _hourAngel+_baseAngel*normal);
        }

        protected override void OnNewHours(Night.HourData hour) => _hourAngel = GetAngelHour(hour);

        private float GetAngelHour(Night.HourData hourd)
        {
            _baseAngel = GetBaseAngelHour();
            return (_time == TimeType.T24 ? hourd.Hour * _baseAngel : (hourd.Hour >= 12 ? hourd.Hour - 12 : hourd.Hour) * _baseAngel);
        }
        
        private float GetBaseAngelHour() => _time == TimeType.T24 ? -360 / 24 : -360 / 12;

        public enum TimeType
        {
            T24, T12
        }
    }
}