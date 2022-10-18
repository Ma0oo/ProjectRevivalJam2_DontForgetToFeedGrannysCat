using DefaultNamespace.Cat;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace.VoiceSystem
{
    public class CatVoice : SerializedMonoBehaviour, ICatPart
    {
        [SerializeField] private IVoice _voice;
        [SerializeField] private AudioClip _clip;
        
        public void Meow() => _voice.Say(_clip);
    }
}