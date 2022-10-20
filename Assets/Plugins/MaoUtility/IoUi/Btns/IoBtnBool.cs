using System;
using Lean.Gui;
using Plugins.MaoUtility.Localization.Core;
using Plugins.MaoUtility.MonoBehsGameHelper.UI;
using UnityEngine;

namespace Plugins.MaoUtility.IoUi.Btns
{
    public class IoBtnBool : IOBtn<bool>
    {
        public LeanButton Btn;
        [SerializeField] private PanelUI PanelUi;

        [SerializeField] private string _idStateForPanelToOn;
        [SerializeField] private string _idStateForPanelToOff;

        public override event Action<bool, IOBtn<bool>> Updated;
        
        public override void SetWithoutEvent(bool value) => PanelUi.TryCustomAction(value ? _idStateForPanelToOn : _idStateForPanelToOff);
        
        public override void Init(Func<bool> get, Action<bool> set)
        {
            SetWithoutEvent(get());
            Btn.OnClick.AddListener(() =>
            {
                set(!get());
                SetWithoutEvent(get());
                Updated?.Invoke(get(), this);
            });
        }
    }
}