using System;
using DefaultNamespace.ApartmentSystem;
using DefaultNamespace.Cat;
using DefaultNamespace.Player;
using UnityEngine;

namespace DefaultNamespace.VoiceSystem
{
    public interface IVoice : IPlayerUnitPart, ICatPart, IRoomPart
    {
        void Say(AudioClip key);
        void StopCurrent();
        event Action OnEnd;
        event Action Started;
    }
}