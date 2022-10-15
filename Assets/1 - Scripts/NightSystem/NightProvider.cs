using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.ScenesLogic.Game
{
    [CreateAssetMenu(menuName = "Game/Nights/Provider", order = 51)]
    public class NightProvider : ScriptableObject
    {
        public IReadOnlyCollection<Night> Nights => _nights;
        [SerializeField] private Night[] _nights;
    }
}