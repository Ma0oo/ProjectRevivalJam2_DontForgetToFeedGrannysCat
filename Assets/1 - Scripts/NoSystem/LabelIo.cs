using System;
using Plugins.MaoUtility.IoUi.Btns.Components;
using TMPro;
using UnityEngine;

namespace DataGame.Keys
{
    public class LabelIo : ComponentIoBtn
    {
        [SerializeField] private TextMeshProUGUI _label;

        public string Text
        {
            get => _label.text;
            set => _label.text = value;
        }
    }
}