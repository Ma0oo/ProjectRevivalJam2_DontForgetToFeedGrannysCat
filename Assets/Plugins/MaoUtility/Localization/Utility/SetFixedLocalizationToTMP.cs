using System;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.Localization.Core;
using TMPro;
using UnityEngine;

namespace Plugins.MaoUtility.Localization.Utility
{
    [DiMark]
    public class SetFixedLocalizationToTMP : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private RequestString _requestString;
        [SerializeField] private string _id;

        [DiInject] private Localizator _localizator;

        private void Start()
        {
            Set();
            _localizator.ChangeLanguage += Set;
        }

        private void Set() => _label.text = _requestString.Get(_id);
    }
}