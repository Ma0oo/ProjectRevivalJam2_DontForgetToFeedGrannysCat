using System;
using Plugins.MaoUtility.MaoExts.Static;
using Plugins.MaoUtility.MonoBehsGameHelper.UI;
using UnityEngine;

namespace NoSystem
{
    public class FadeScreen : MonoBehaviour
    {
        [SerializeField] private PanelUI _panelUi;
        [SerializeField] private string IdInstanceOn;
        [SerializeField] private string IdInstanceOff;

        public Canvas Canvas => _canvas;
        [SerializeField] private Canvas _canvas;
        [SerializeField, Min(0)] private float _delayToFullOn;

        public void Transition(Action callback)
        {
            _panelUi.SetActive(true);
            CoroutineGame.Instance.Wait(_delayToFullOn, () =>
            {
                callback();
                _panelUi.SetActive(false);
            });
        }

        public void On() => _panelUi.SetActive(true);
        
        public void On(Action callback)
        {
            _panelUi.SetActive(true);
            CoroutineGame.Instance.Wait(_delayToFullOn, () => callback());
        }

        public void Off() => _panelUi.SetActive(false);

        public void SetInstanceState(bool isOn) => _panelUi.TryCustomAction(isOn ? IdInstanceOn : IdInstanceOff);
    }
}