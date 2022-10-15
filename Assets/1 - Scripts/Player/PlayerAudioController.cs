using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Player.Controlls;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.MaoExts.Static;
using UnityEngine;

namespace DefaultNamespace.Player
{
    [DiMark]
    public class PlayerAudioController : MonoBehaviour
    {
        [Header("source")]
        [SerializeField] private AudioSource _sourceOnePrefab;
        [SerializeField] private Transform _pointOneSource;
        [SerializeField] private AudioSource _sourceStep;
        [SerializeField] private float _durationChangeStep;
        [SerializeField, Range(0,1f)] private float _volumeStep;
        
        [Header("Clips")]
        [SerializeField] private AudioClip _step;
        [SerializeField] private ClidData _jump;
        [SerializeField] private ClidData _crouch;
        
        [SerializeField] private ClidData _noToInterect;
        [SerializeField] private ClidData _interected;

        [SerializeField] private PlayerInterector _playerInterector;
        [SerializeField] private CrouchControl _crouchModule;
        [SerializeField] private MoveController _mover;

        private bool _stateWalk;
        private Tween _tween;

        private void Start()
        {
            _sourceOnePrefab.loop = false;
            _sourceStep.loop = true;
            _sourceStep.clip = _step;
            
            _playerInterector.Interected += () => PlayOne(_interected);
            _playerInterector.NoToInterect += () => PlayOne(_noToInterect);
            _mover.Jumped += () => PlayOne(_jump);
            _crouchModule.ToDown += () => PlayOne(_crouch);

            _mover.Walked += () => SetWalk(true);
            _mover.NotWalked += () => SetWalk(false);
        }

        private void SetWalk(bool state)
        {
            if(_stateWalk==state) return;
            _stateWalk = state;
            _tween?.Kill();
            _tween = DOTween.To(() => _sourceStep.volume, x => _sourceStep.volume = x, state ? _volumeStep : 0, _durationChangeStep);
        }

        private void PlayOne(ClidData data)
        {
            var r = _sourceOnePrefab.Spawn(_pointOneSource);
            r.clip = data.Clip;
            r.volume = data.Volume;
            r.Play();
        }

        private void OnDestroy() => _tween?.Kill();

        [System.Serializable]
        public class ClidData
        {
            public AudioClip Clip;
            [Range(0,1f)]public float Volume;
        }
    }
}