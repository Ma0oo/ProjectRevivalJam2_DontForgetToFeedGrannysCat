using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Player.Controlls
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField,Min(0)] private float _speed;
        [SerializeField,Min(0)] private float _speedRun;
        [SerializeField,Min(0)] private float _speedDuration;
        [SerializeField,Min(0)] private float _speedDurationDown;
        [SerializeField] private AnimationCurve _curveAcceleration;
        [SerializeField] private float _gravity;
        
        [SerializeField,Min(0)] private float _jumpH;
        [SerializeField,Min(0)] private float _jumpDuration;
        [SerializeField] private AnimationCurve _jumpCurve;
        [SerializeField,Range(0,1f)] private float _jumpBreake;
        [SerializeField, Min(0)] private float _rangeGroundCheck;
        [SerializeField,Range(0, 1f)] private float _graviteModifareOnGround;

        private float _progressSpeed;
        private float _progressJump;
        private Vector2 _dir;
        private Vector2 _lastNoneZeroDir;
        private bool _isJump;
        private bool _isRun=false;

        public event Action Jumped;
        public event Action Walked;
        public event Action NotWalked;

        private float Speed => _isRun ? _speedRun : _speed;

        private Vector2 Dir => _dir.magnitude < Mathf.Epsilon ? _lastNoneZeroDir : _dir;

        [ShowInInspector]private bool OnGround => !Application.isPlaying ? 
            false : 
            Physics.Raycast(new Ray(_rigidbody.transform.position+_rigidbody.transform.up*0.1f, _rigidbody.transform.up * -1), _rangeGroundCheck);

        private void Start() => _rigidbody.transform.up=Vector3.up;

        public void Move(Vector2 dir)
        {
            if (dir.magnitude < Mathf.Epsilon && _dir.magnitude > Mathf.Epsilon)
                _lastNoneZeroDir = _dir;
            _dir = dir;
        }

        public void SetRun(bool run) => _isRun = run;

        private void FixedUpdate()
        {
            CalculateProgress();
            _rigidbody.velocity = GetVelocity();
            if (OnGround && _rigidbody.velocity.magnitude > Mathf.Epsilon)
            {
                Walked?.Invoke();
            }
            else
            {
                NotWalked?.Invoke();
            }
        }

        public void Jump()
        {
            if (OnGround)
            {
                Jumped?.Invoke();
                _isJump = true;
            }
        }

        private void CalculateProgress()
        {
            _progressSpeed += (_dir.magnitude > Mathf.Epsilon ? (1 / _speedDuration) : -(1 / _speedDurationDown))*Time.fixedDeltaTime;
            _progressJump += _isJump ? (1 / _jumpDuration) * Time.fixedDeltaTime : 0;

            _progressSpeed = Mathf.Clamp(_progressSpeed, 0, 1);
            if (_progressJump >= 1)
            {
                _isJump = false;
                _progressJump = 0;
            }
        }

        private Vector3 GetVelocity()
        {
            Vector3 velocity = new Vector3();
            Vector3 dirV3 = _speed * Dir.x * transform.right + (Dir.y>0 ?Speed : _speed) * Dir.y*transform.forward;
            velocity += dirV3 * _curveAcceleration.Evaluate(_progressSpeed);
            if (_isJump)
            {
                var jumpY = _jumpH * _curveAcceleration.Evaluate(_progressJump);
                if (jumpY > 0.1f) velocity *= _jumpBreake;
                velocity.y = jumpY;
            }
            else
            {
                velocity.y = OnGround ? -_gravity * _graviteModifareOnGround : -_gravity;
            }
            return velocity;
        }
    }
}
