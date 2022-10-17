using DefaultNamespace.ScenesLogic.Game;
using UnityEngine;

namespace DataGame.Keys
{
    public class ViewGameTimeLight : BaseViewGameTime
    {
        [SerializeField] private Light _light;
        [SerializeField] private Gradient _gradient;
        [SerializeField] private AnimationCurve _curveIntensive;

        private float _hourPart = 1f / 24;
        private int _currentHour;

        protected override void OnNewNormal(float normal)
        {
            _light.color = _gradient.Evaluate(NormalByAll(normal));
            _light.intensity = _curveIntensive.Evaluate(NormalByAll(normal));
        }

        private float NormalByAll(float normal) => _hourPart * _currentHour + _hourPart * normal;

        protected override void OnNewHours(Night.HourData hour)
        {
            _currentHour = hour.Hour;
        }
    }
}