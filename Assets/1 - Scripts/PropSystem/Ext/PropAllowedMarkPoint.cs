using System.Collections.Generic;
using System.Linq;
using NoSystem;
using Sirenix.Utilities;
using UnityEngine;

namespace DefaultNamespace.PropSystem
{
    public class PropAllowedMarkPoint : MonoBehaviour, IPropPart
    {
        [SerializeField] private PropPointMark[] _marks;

        public bool ContainsMark(PropPointMark mark) => _marks.Contains(mark);
        
        public bool ContainsMark(IEnumerable<PropPointMark> marks)
        {
            foreach (var propPointMark in marks)
                if (ContainsMark(propPointMark))
                    return true;
            return false;
        }
    }
}