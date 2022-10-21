using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.DILocator.Core.BaseClasses;
using UnityEngine;

namespace DefaultNamespace.SubtitlesSystem
{
    public class RegisterSubtitlesScene : RegisterDI
    {
        public const string IDSceneSubtitles = "SceneSubtitles";
        
        [SerializeField] private Subtitles _subtitles;
        
        protected override void Register(DI di) => di.Set(_subtitles, IDSceneSubtitles);

        protected override void Unregister(DI di) => di.Remove<Subtitles>(IDSceneSubtitles);
    }
}