using System;
using DataGame.Keys;
using Plugins.MaoUtility.Localization.Utility;
using Plugins.MaoUtility.MaoExts.Static;
using Plugins.MaoUtility.SceneFlow;
using Sirenix.Utilities;
using TMPro;
using UnityEngine;

namespace ScenesLogic.Menu
{
    public class CreditPanel : SceneLogic
    {
        [Header("Prefab")]
        [SerializeField] private LinkPanel _linkViewPrefab;
        [SerializeField] private TextMeshProUGUI _sectionLabel;
        
        [Header("Data")]
        [SerializeField] private Section[] _sections;
        [SerializeField] private LinkPanel _nameJamPanel;
        [SerializeField] private Link _jamLink;
        
        [SerializeField] private Transform _pointSpawnContent;
        [SerializeField] private RequestString _requestString;
        
        private void Start()
        {
            InitLink(_nameJamPanel, _jamLink);
            _sections.ForEach(SpawnSection);
        }

        private void SpawnSection(Section obj)
        {
            _sectionLabel.Spawn(_pointSpawnContent).text = _requestString.Get("CREDIT_"+obj.KeySection);
            obj.Links.ForEach(x => InitLink(_linkViewPrefab.Spawn(_pointSpawnContent), x));
        }

        private void InitLink(LinkPanel linkPanel, Link linkData) 
            => linkPanel.Init("CREDIT_"+linkData.NameKey, "CREDIT_"+linkData.LinkKey, linkData.Url);


        [System.Serializable]
        public class Section
        {
            public string KeySection; 
            public Link[] Links;
        }
        
        [System.Serializable]
        public class Link
        {
            public string NameKey;
            public string LinkKey;
            [Multiline(3)]public string Url;
        }
    }
}