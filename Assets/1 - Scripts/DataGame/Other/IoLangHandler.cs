using System;
using Lean.Gui;
using Plugins.MaoUtility.IoUi.Core;
using Plugins.MaoUtility.Localization.Core;
using UnityEngine;

namespace DataGame.Other
{
    public class IoLangHandler : IoGroupHandler
    {
        public Action<LanguageMark> Selected;

        [SerializeField] private LanguageMark _engData;
        [SerializeField] private LanguageMark _rusData;
        [SerializeField] private LeanButton _eng;
        [SerializeField] private LeanButton _rus;

        private void Start()
        {
            _eng.OnClick.AddListener(()=>Selected?.Invoke(_engData));
            _rus.OnClick.AddListener(()=>Selected?.Invoke(_rusData));
            Register<IoLangHandler>();
        }
    }
}