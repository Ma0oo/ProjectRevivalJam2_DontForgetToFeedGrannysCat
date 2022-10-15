using System;
using Plugins.MaoUtility.IoUi.Btns.Components;
using Plugins.MaoUtility.Localization.Utility;
using TMPro;
using UnityEngine;

namespace DataGame.Keys
{
    public class LabelIo : ComponentIoBtn
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private RequestString _requestString;

        public void SetTextById(string id, string mes)
        {
            Text = _requestString.GetWithCustomLog(id, mes);
        }
        
        private string Text
        {
            get => _label.text;
            set => _label.text = value;
        }
    }
}