using Plugins.MaoUtility.Localization.Utility;
using Plugins.MaoUtility.MaoExts.Static;
using Plugins.MaoUtility.MonoBehsGameHelper.UI;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.SubtitlesSystem
{
    public class Subtitles : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private PanelUI _panelUi;

        public RequestString RequestString => _requestString??=gameObject.GetComponentOrCreate<RequestString>();
        private RequestString _requestString;

        public void Show(string content, MetaData metaDat)
        {
            _label.color = metaDat.Color;
            _label.text = $"{RequestString.Get(metaDat.KeyOwner)}: {content}";
        }
    }
}