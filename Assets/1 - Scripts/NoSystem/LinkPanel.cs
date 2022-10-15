using System;
using Lean.Gui;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.Localization.Utility;
using Plugins.MaoUtility.MaoExts.Static;
using TMPro;
using UnityEngine;

namespace DataGame.Keys
{
    public class LinkPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _labelName;
        [SerializeField] private TextMeshProUGUI _labelLink;
        [SerializeField] private LeanButton _btn;
        [SerializeField] private RequestString _requestString;

        private string _keyName;
        private string _keyLink;
        private string _url;

        private void Start()
        {
            _btn.OnClick.AddListener(() => _url.With(x => Application.OpenURL(x), !string.IsNullOrWhiteSpace(_url)));
            _requestString.LanguageChanged += SetKey;
        }

        public void Init(string nameKey, string linkKey, string url)
        {
            _keyName = nameKey;
            _keyLink = linkKey;
            _url = url;
            SetKey();
        }

        private void SetKey()
        {
            _labelName.text = _requestString.Get(_keyName);
            _labelLink.text = _requestString.Get(_keyLink);
        }
    }
}