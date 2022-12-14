using NoSystem;
using Plugins.MaoUtility.InputModule.Core.BaseClasses;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace.Cat
{
    public class CatAnimatorControler : MonoBehaviour, ICatPart
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _nameSeatProperty;
        [SerializeField] private string _nameSleepProperty;
        
        [Button]public void SetSeat(bool value)
        {
            OffAll(value);
            _animator.SetBool(_nameSeatProperty, value);
        }
        
        [Button]public void SetSleep(bool value)
        {
            OffAll(value);
            _animator.SetBool(_nameSleepProperty, value);
        }

        [Button]public void Idel() => OffAll(true);

        private void OffAll(bool toActive)
        {
            if(!toActive) return;
            SetSeat(false);
            SetSleep(false);
        }
    }
}