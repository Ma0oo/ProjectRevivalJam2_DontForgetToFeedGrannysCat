using System;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.Localization.Utility;
using Plugins.MaoUtility.MonoBehsGameHelper.UI;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.NoteSystem
{
    [DiMark]
    public class NoteUI : MonoBehaviour
    {
        [SerializeField] private PanelUI _panelUi;
        [SerializeField] private RequestString _requestString;
        [SerializeField] private TextMeshProUGUI _label;

        [DiInject] private NoteServices _noteServices;

        [DiInject] private void Init() => _noteServices.SM.EnterTo += OnEnter;

        private void OnEnter(NoteState obj)
        {
            if(obj is NoNote)
            {
                _panelUi.SetSafeActive(false);
            }
            else
            {
                var content = (NoteContetn)obj;
                _panelUi.SetSafeActive(true);
                _label.text = _requestString.Get(content.KeyContent);
            }
        }
    }
}