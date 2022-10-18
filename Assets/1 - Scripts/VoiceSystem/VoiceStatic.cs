using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using Plugins.MaoUtility.DataManagers;
using Plugins.MaoUtility.Localization.Utility;
using Plugins.MaoUtility.MaoExts.Static;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace.VoiceSystem
{
    public class VoiceStatic : MonoBehaviour, IVoice
    {
        [SerializeField] private AudioSource _source;
        private string _idCor;

        public void Say(AudioClip clip)
        {
            if(_source.isPlaying) StopCurrent();
            _source.clip = clip;
            _source.Play();
            Started?.Invoke();
            _idCor = CoroutineGame.Instance.Wait(clip.length, StopCurrent);
        }

        public void StopCurrent()
        {
            CoroutineGame.Instance.StopWait(_idCor);
            _source.Stop();
            OnEnd?.Invoke();
        }

        public event Action OnEnd;
        public event Action Started;
    }
}