using Plugins.MaoUtility.DILocator.Core;
using UnityEngine;

namespace Plugins.MaoUtility.SceneFlow
{
    public abstract class SceneLogic : MonoBehaviour
    {
        public OwnerSceneLogic Owner => _owner??=DI.Instance.Get<OwnerSceneLogic>();
        private OwnerSceneLogic _owner;
        
        public virtual void PreAwake(){}
    }
}