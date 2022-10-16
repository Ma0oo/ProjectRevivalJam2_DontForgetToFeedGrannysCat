using Plugins.MaoUtility.DataManagers;

namespace Plugins.MaoUtility.SceneShareData
{
    [System.Serializable]
    public class SceneShareDataProvider : DataManagerSystemObject<IShereSceneData>
    {
        private static SceneShareDataProvider _instance;
        public static SceneShareDataProvider Instance => _instance ??= new SceneShareDataProvider();
        
        private SceneShareDataProvider() { }
    }
}