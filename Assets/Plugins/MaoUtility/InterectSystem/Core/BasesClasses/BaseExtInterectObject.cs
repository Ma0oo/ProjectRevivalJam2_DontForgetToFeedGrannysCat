using System;
using Plugins.MaoUtility.MaoExts.Static;
using UnityEngine;

namespace Plugins.MaoUtility.InterectSystem.Core.BasesClasses
{
    public abstract class BaseExtInterectObject : MonoBehaviour
    {
        [SerializeField] private InterectObject _interectObject;

        protected virtual void Start()
        {
            _interectObject.Interected += OnInterected;
        }

        protected abstract void OnInterected(InterectActionBase obj);
        
        
        protected void TryCast<T>(InterectActionBase obj, Action<T> callback) where T : InterectActionBase 
            => (obj as T)?.With(x => callback(x));
    }
}