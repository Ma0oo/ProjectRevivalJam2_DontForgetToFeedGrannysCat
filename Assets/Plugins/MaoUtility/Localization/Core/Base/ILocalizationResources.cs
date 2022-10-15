using Plugins.MaoUtility.SceneFlow;
using UnityEngine.SocialPlatforms;

namespace Plugins.MaoUtility.Localization.Core
{
    public interface ILocalizationResources<T>
    {
        bool HasId(string id);
        T Get(string id);
    }
}