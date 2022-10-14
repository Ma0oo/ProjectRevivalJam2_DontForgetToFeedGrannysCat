using System;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.MaoUtility.IoUi.Btns
{
    public class IoBtnFloat : IOBtn<float>
    {
        public override event Action<float, IOBtn<float>> Updated;

        [SerializeField]private Slider _slider;
        
        public override void SetWithoutEvent(float value) => _slider.value = value;

        public override void Init(Func<float> get, Action<float> set)
        {
            SetWithoutEvent(get());
            _slider.onValueChanged.AddListener(x =>
            {
                set(x);
                SetWithoutEvent(get());
                Updated?.Invoke(get(), this);
            });
        }
    }
}