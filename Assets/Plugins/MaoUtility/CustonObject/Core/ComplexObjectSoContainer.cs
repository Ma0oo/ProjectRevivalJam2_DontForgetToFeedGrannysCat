using System;
using Plugins.MaoUtility.CustonObject.Core;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace Plugins.MaoUtility.CustonObject.So
{
    public abstract class ComplexObjectSoContainer<OBJ, CONFIG, DATA> : ScriptableObject 
        where DATA : class, ICloneable 
        where CONFIG : class, ICloneable 
        where OBJ : ComplexObject<CONFIG, DATA>
    {
        public OBJ NewComplexObject => _origin.Clone() as OBJ;
        [SerializeField, HideLabel] private OBJ _origin;

        public OBJ SharedComplexObject => _privateShared;
        [SerializeField, ReadOnly] private OBJ _privateShared;

        public void Init() => _privateShared = NewComplexObject;
    }
}