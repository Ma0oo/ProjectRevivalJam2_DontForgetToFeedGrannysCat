using DefaultNamespace.ScenesLogic.Game;
using UnityEngine;

namespace DataGame.Keys
{
    public class ViewGameTimeSkybox : BaseViewGameTime
    {
        [SerializeField] private Gradient _gradient;
        [SerializeField] private string _nameProp = "_SkyTint";
        
        private float _hourPart = 1f / 24;
        private int _currentHour;
        private Material _material;
        

        protected override void CustomStart()
        {
            base.CustomStart();
            _material = RenderSettings.skybox;
        }

        protected override void OnNewNormal(float normal)
        {
            _material.SetColor(_nameProp, _gradient.Evaluate(NormalByAll(normal)));
        }

        private float NormalByAll(float normal) => _hourPart * _currentHour + _hourPart * normal;

        protected override void OnNewHours(Night.HourData hour)
        {
            _currentHour = hour.Hour;
        }
    }
}