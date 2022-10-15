using Plugins.MaoUtility.DataManagers;
using UnityEngine.SceneManagement;

namespace Plugins.MaoUtility.DataBetweenScene
{
    [System.Serializable]
    public class SceneShareDataProvider : DataManagerSystemObject<IShereSceneData>
    {
        private static SceneShareDataProvider _instance;
        public static SceneShareDataProvider Instance => _instance ??= new SceneShareDataProvider();

        private SceneShareDataProvider()
        {
        }
    }
}