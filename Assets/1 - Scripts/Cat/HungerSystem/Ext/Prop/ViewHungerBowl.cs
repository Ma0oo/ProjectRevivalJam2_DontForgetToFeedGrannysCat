using DefaultNamespace.PropSystem;
using UnityEngine;

namespace DefaultNamespace.Cat.HungerSystem.Ext.Prop
{
    public class ViewHungerBowl : MonoBehaviour, IPropPart
    {
        private IHungerControl _hungerControl;

        [SerializeField] private float _minYPos;
        [SerializeField] private float _maxYPos;
        [SerializeField] private Transform _targetObjectView;

        public void Init(IHungerControl hungerControl)
        {
            _hungerControl = hungerControl;
            _hungerControl.Stat.Changed += OnChanged;
        }

        private void OnChanged()
        {
            var y = Mathf.Lerp(_minYPos, _maxYPos, _hungerControl.Stat.Current / _hungerControl.Stat.Max);
            var pos = _targetObjectView.localPosition;
            pos.y = y;
            _targetObjectView.localPosition = pos;
        }
    }
}