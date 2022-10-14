using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.MaoExts.Static;
using UnityEngine;
using Object = System.Object;

namespace Plugins.MaoUtility.DILocator.Core
{
    public static class DiExt
    {
        public static void InjectObj(this Object obj, DI context) => context.Inject(obj);

        public static void InjectGO(this GameObject gameObject, DI context, bool includeChilds = true)
        {
            IEnumerable<MonoBehaviour> monobehs = includeChilds ? gameObject.GetComponentsInChildren<MonoBehaviour>(true) :  gameObject.GetComponents<MonoBehaviour>();
            monobehs = monobehs.Where(x => CustomAttributeExtensions.GetCustomAttribute<DiMark>((MemberInfo) x.GetType()) != null);
            foreach (var monoBehaviour in monobehs) monoBehaviour.InjectObj(context);
        }

        public static GameObject SpawnWithDi(GameObject prefab, DI context, bool includedChilds = true)
        {
            prefab.SetActive(false);
            var result = prefab.Spawn();
            prefab.SetActive(true);
            result.InjectGO(context, includedChilds);
            return result;
        }
        
        public static T SpawnWithDi<T>(T prefab, DI context, bool includedChilds = true) where T : Component
        {
            prefab.gameObject.SetActive(false);
            var result = prefab.Spawn();
            prefab.gameObject.SetActive(true);
            result.gameObject.InjectGO(context, includedChilds);
            return result;
        }
    }
}