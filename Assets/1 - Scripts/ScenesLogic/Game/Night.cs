using DefaultNamespace.ApartmentSystem;
using UnityEngine;

namespace DefaultNamespace.ScenesLogic.Game
{
    [CreateAssetMenu(menuName = "Game/Night", order = 51)]
    public class Night : ScriptableObject
    {
        public Apartment Apartment;
    }
}