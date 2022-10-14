using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.DILocator.Core.BaseClasses;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Plugins.MaoUtility.SceneFlow
{
    [RequireComponent(typeof(InjectScene), typeof(OwnerSceneLogic))]
    [AddComponentMenu("Mao Mono/Pre Awake")]
    public class PreAwake : MonoBehaviour
    {
        public RegisterDI[] DiRegisters;
        public InjectScene InjectScene;
        public OwnerSceneLogic OwnerLogic;

        private void Awake()
        {
            DI.Instance.Set(OwnerLogic);
            DiRegisters.ForEach(x => x.Register());
            InjectScene.Inject();
            OwnerLogic.PreAwake();
        }

        private void OnDestroy()
        {
            DI.Instance.Remove<OwnerSceneLogic>();
            DiRegisters.ForEach(x => x.Unregister());
        }

        [Button]
        private void Valid() => OnValidate();

        private void OnValidate()
        {
            DiRegisters = FindObjectsOfType<RegisterDI>();
            InjectScene = GetComponent<InjectScene>();
            OwnerLogic = GetComponent<OwnerSceneLogic>();
        }
    }
}