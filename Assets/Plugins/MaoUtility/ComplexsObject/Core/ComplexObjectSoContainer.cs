using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Plugins.MaoUtility.ComplexsObject.Core
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