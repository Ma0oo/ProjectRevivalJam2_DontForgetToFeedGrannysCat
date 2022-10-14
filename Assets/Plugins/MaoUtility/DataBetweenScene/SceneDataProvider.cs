using Plugins.MaoUtility.DataManagers;

namespace Plugins.MaoUtility.DataBetweenScene
{
    public class SceneDataProvider : DataManagerSystemObject<ISceneData>
    {
        private static SceneDataProvider _instance;
        public static SceneDataProvider Instance => _instance ??= new SceneDataProvider();
        
        private SceneDataProvider() { }
    }
}