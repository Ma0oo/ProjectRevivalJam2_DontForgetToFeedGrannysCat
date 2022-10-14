using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DataGame.Keys
{
    public class ViewSlider : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Slider _slider;

        private void Start()
        {
            UpdateView();
            _slider.onValueChanged.AddListener(x=>UpdateView());
        }

        private void UpdateView() => _text.text = (((float) (int) (_slider.value * 100)) / 100).ToString();
    }
}