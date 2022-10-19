using System;
using DefaultNamespace.ScenesLogic.Game;
using Plugins.MaoUtility.MonoBehsGameHelper.ValueContainers;

namespace DefaultNamespace.Cat.HungerSystem
{
    public interface IHungerControl
    {
        public IValueContainer<float> Stat { get; }
    }
}