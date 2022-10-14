using System;
using UnityEngine;

namespace Player.Controlls
{
    public class CameraPlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Camera _camera;
        [SerializeField] private float _sensity;

        [SerializeField] private float _downAngel=80;
        [SerializeField] private float _upAngel=-80;

        private float _angelXCamera=0;
        private float _rotateY;
        private Vector2 _dir;

        private void OnEnable() => InitAngel();

        public void InitAngel() 
            => _rotateY = _rigidbody.transform.eulerAngles.y;

        private void Update()
        {
            _angelXCamera += _dir.y * _sensity;
            if (_angelXCamera < _upAngel) _angelXCamera = _upAngel;
            if (_angelXCamera > _downAngel) _angelXCamera = _downAngel;
            
            _rotateY += _dir.x * _sensity;
        }

        private void LateUpdate()
        {
            _camera.transform.eulerAngles = new Vector3(_angelXCamera, _camera.transform.eulerAngles.y, _camera.transform.eulerAngles.z);
            _rigidbody.transform.eulerAngles = new Vector3(_rigidbody.transform.eulerAngles.x, _rotateY, _rigidbody.transform.eulerAngles.z);
        }

        public void Rotate(Vector2 dir)
        {
            _dir = dir;
        }
    }
}