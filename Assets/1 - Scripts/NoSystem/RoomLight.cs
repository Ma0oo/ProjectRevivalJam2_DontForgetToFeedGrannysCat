using System;
using DefaultNamespace.ApartmentSystem;
using UnityEngine;

namespace DataGame.Keys
{
    public class RoomLight : MonoBehaviour, IRoomPart
    {
        [SerializeField] private Light _light;
        
        private Color _defaultColor;
        private float _defaultIntensity;

        private void Start()
        {
            _defaultColor = _light.color;
            _defaultIntensity = _light.intensity;
        }

        public void SetNormalIntensity(float normal) => _light.intensity = Mathf.Lerp(0, _defaultIntensity, normal);

        public void SetColor(Color color) => _light.color = color;

        public void ZeroColor() => _light.color = _defaultColor;
    }
}