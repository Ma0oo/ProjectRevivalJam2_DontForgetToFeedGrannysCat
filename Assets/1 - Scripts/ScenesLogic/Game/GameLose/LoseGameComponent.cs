using System;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.SceneFlow;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace.ScenesLogic.Game.GameLose
{
    [DiMark]
    public class LoseGameComponent : MonoBehaviour, IGameLose
    {
        [DiInject] private OwnerSceneLogic _ownerSceneLogic;
        public event Action InLose;

        private void OnEnable()
        {
            _ownerSceneLogic.Get<GameResult>()?.Register(this);
        }

        private void OnDisable()
        {
            _ownerSceneLogic.Get<GameResult>()?.UnRegister(this);
        }

        [Button]public void Lose()
        {
            InLose?.Invoke();
        }
    }
}