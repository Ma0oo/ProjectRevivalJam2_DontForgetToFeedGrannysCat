using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NoSystem;
using Player.Controlls;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.MaoExts.Static;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace.Player
{
    [DiMark]
    public class PlayerAudioController : MonoBehaviour
    {
        [Header("source")]
        [SerializeField] private AudioSource _sourceOnePrefab;
        [SerializeField] private Transform _pointOneSource;
        [SerializeField] private Transform _pointStep;
        [SerializeField] private Vector2 _rangeBetweenStep;
        
        [Header("Clips")]
        [SerializeField] private ClidData _step;
        [SerializeField] private ClidData _jump;
        [SerializeField] private ClidData _crouch;
        
        [SerializeField] private ClidData _noToInterect;
        [SerializeField] private ClidData _interected;

        [SerializeField] private PlayerInterector _playerInterector;
        [SerializeField] private CrouchControl _crouchModule;
        [SerializeField] private MoveController _mover;

        private bool _stateWalk;
        private Tween _tween;
        private string _walkSoundTween="";

        private void Start()
        {
            _playerInterector.Interected += () => PlayOne(_interected, _pointOneSource);
            _playerInterector.NoToInterect += () => PlayOne(_noToInterect, _pointOneSource);
            _mover.Jumped += () => PlayOne(_jump, _pointOneSource);
            _crouchModule.ToDown += () => PlayOne(_crouch, _pointOneSource);

            _mover.Walked += () => SetWalk(true);
            _mover.NotWalked += () => SetWalk(false);
            
            _stateWalk = true;
            SetWalk(false);
        }

        private void OnDisable()
        {
            _mover.Walked -= () => SetWalk(true);
            _mover.NotWalked -= () => SetWalk(false);
            SetWalk(false);
        }

        private void SetWalk(bool state)
        {
            if (_stateWalk == state) return;
            _stateWalk = state;
            if (state) CreateTween();
            else CoroutineGame.Instance.StopWait(_walkSoundTween);
        }

        private void CreateTween()
        {
            PlayOne(_step, _pointStep);
            var timeWait = Random.Range(_rangeBetweenStep.x, _rangeBetweenStep.y);
            if (_mover.IsRun) timeWait /= 2;
            _walkSoundTween = CoroutineGame.Instance.Wait(timeWait, CreateTween);
        }

        private void PlayOne(ClidData data, Transform point)
        {
            var r = _sourceOnePrefab.Spawn(point);
            r.loop = false;
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