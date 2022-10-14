using System;
using System.Collections.Generic;
using System.Linq;
using Plugins.MaoUtility.DataManagers;
using Sirenix.OdinInspector;

namespace Plugins.MaoUtility.SceneFlow
{
    public class OwnerSceneLogic : DataManagerMonoBeh<SceneLogic>
    {
        public void PreAwake() => Datas.ForEach(x => x.PreAwake());

        [Button]
        private void OnValidate()
        {
            Datas = FindObjectsOfType<SceneLogic>().ToList();
            HashSet<Type> typeCehck = new HashSet<Type>();
        }
    }
}