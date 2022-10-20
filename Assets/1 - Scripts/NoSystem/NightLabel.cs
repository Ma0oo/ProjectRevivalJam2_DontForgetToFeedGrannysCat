using System;
using DataGame.Save;
using DefaultNamespace.ScenesLogic.Game;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.Localization.Core;
using Plugins.MaoUtility.Localization.Utility;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace DataGame.Keys
{
    [DiMark]
    public class NightLabel : MonoBehaviour
    {
        [SerializeField] private RequestString _requestString;
        [SerializeField] private TextMeshProUGUI _label;

        [DiInject] private SaveDataProvider _saveDataProvider;
        [DiInject] private Localizator _localizator;
        private int _lastI;

        private void Start()
        {
            SetDay(_saveDataProvider.Current.Night);
            _localizator.ChangeLanguage += () => SetDay(_lastI);
        }

        [Button]private void SetDay(int i)
        {
            i = i % 7;
            _lastI = i;
            _label.text = $"{_requestString.Get("KEY_NIGHTLABEL")}: {_requestString.Get("KEY_" + GetKeyByIndex(i))}";
        }

        private string GetKeyByIndex(int current)
        {
            switch (current)
            {
                case 0: return "MONDAY";
                case 1: return "TUESDAY";
                case 2: return "WEDNESDAY";
                case 3: return "THURSDAY";
                case 4: return "FRIDAY";
                case 5: return "SATURDAY";
                case 6: return "SUNDAY";
                default: return "UNKNONW";
            }
        }
    }
}