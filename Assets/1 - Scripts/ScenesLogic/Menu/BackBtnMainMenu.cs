using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.InputModule.AutoSub;
using Plugins.MaoUtility.InputModule.Core;
using Plugins.MaoUtility.SceneFlow;
using ScenesLogic.Menu.Input;
using UnityEngine;

namespace ScenesLogic.Menu
{
    [DiMark]
    public class BackBtnMainMenu : MonoBehaviour
    {
        [DiInject] private InputManager _inputManager;
        [DiInject] private OwnerSceneLogic _owner;

        private SubInputInterface<IMenuInput> _input;

        private void Start()
        {
            _input = new SubInputInterface<IMenuInput>(x =>
            {
                x.BakcByHistoryPanel += Back;
            }, x =>
            {
                x.BakcByHistoryPanel -= Back;
            }, _inputManager);
            _input.SubscribeAction(true);
        }

        private void Back() => _owner.Get<PanelMenu>()?.GoBack();
    }
}