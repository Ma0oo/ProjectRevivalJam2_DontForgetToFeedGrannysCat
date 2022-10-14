using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Player.Controlls
{
    public class CrouchControl : MonoBehaviour
    {
        [SerializeField] private CapsuleCollider _collider;
        [SerializeField] private Camera _camera;
        [SerializeField] private Data _on;
        [SerializeField] private Data _off;
        [SerializeField] private AnimationCurve _toOnCurve;
        [SerializeField] private AnimationCurve _toOffCurve;
        [SerializeField, Min(0)] private float _durationChangeState;

        private AnimationCurve Curve => _isToOn ? _toOnCurve : _toOffCurve;

        private float _progress;
        private bool _isToOn;
        private Tween _tweenChange;

        [Button]public void SetState(bool state)
        {
            _tweenChange?.Kill();
            _isToOn = state;
            _tweenChange = DOTween.To(() => _progress, x => _progress = x, state ? 1 : 0, GetDuration())
                .OnUpdate(() => ApplayData())
                .OnComplete(() => ApplayData());
        }

        private float GetDuration()
        {
            if (_isToOn)
                return (1 - _progress) * _durationChangeState;
            else
                return _progress * _durationChangeState;
        }

        private void ApplayData()
        {
            var normal = Curve.Evaluate(_progress);
            _collider.center = Vector3.Lerp(_off.Center, _on.Center, normal);
            _collider.height = Mathf.Lerp(_off.H, _on.H, normal);
            _camera.transform.localPosition = Vector3.Lerp(_off.LocalPosCam, _on.LocalPosCam, normal);
        }
        
        [System.Serializable]
        public class  Data
        {
            public Vector3 LocalPosCam;
            public Vector3 Center;
            public float H;
        }
    }
}