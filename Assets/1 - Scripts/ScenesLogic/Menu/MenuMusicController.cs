using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NoSystem;
using Plugins.MaoUtility.SceneFlow;
using UnityEngine;

namespace ScenesLogic.Menu
{
    public class MenuMusicController : SceneLogic
    {
        private MainPanelMenu PanelMenu => Owner.Get<MainPanelMenu>();

        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField, Range(0, 1f)] private float _volumeSoundOn;
        [SerializeField] private float _soundOnDuration;
        [SerializeField] private float _soundOffDuration;
        
        private Tween _tween;

        private void Awake()
        {
            _source.clip = _audioClip;
            _source.volume = 0;
            _source.Play();
            
            PanelMenu.FadeOnStartOff+= ()=> SetVolume(true);
            PanelMenu.GameStarted += ()=> SetVolume(false);
        }

        public void SetVolume(bool toOn)
        {
            _tween?.Kill();
            _tween = DOTween.To(() => _source.volume, 
                x => _source.volume = x, 
                toOn ? _volumeSoundOn : 0, 
                toOn ? _soundOnDuration : _soundOffDuration);
        }
    }
}