using System;
using DefaultNamespace.ScenesLogic.Game.Input;
using NoSystem;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.SceneFlow;
using UnityEngine;

namespace ScenesLogic.Game
{
    public class GameCursorControll : SceneLogic
    {
        private void Start()
        {
            var gamePanel = Owner.Get<GamePanel>();

            gamePanel.NewStateMenuPanel += SetVisibelPanel;
            SetVisibelPanel(false);
        }

        private void SetVisibelPanel(bool obj)
        {
            if (obj)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        private void OnDestroy()
        {
            SetVisibelPanel(true);
        }
    }
}