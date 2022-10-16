using DefaultNamespace.Player;
using NoSystem;
using Player.Input;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.InputModule.AutoSub;
using Plugins.MaoUtility.InputModule.Core;
using Plugins.MaoUtility.MaoExts.Static;
using UnityEngine;

namespace Player.Controlls
{
    [DiMark]
    public class PlayerController : MonoBehaviour, IPlayerUnitPart
    {
        [DiInject] private InputManager _inputManager;

        [SerializeField] private MoveController _mover;
        [SerializeField] private CameraPlayerController _cameraPlayer;
        [SerializeField] private CrouchControl _crouchControl;

        private SubInputClass<PlayerMoveInput> _subMove;

        private void Awake()
        {
            _subMove = new SubInputClass<PlayerMoveInput>(Reg, Unreg, _inputManager);
        }

        private void OnDisable()
        {
            _subMove.SubscribeAction(false);
        }

        private void OnEnable()
        {
            _subMove.SubscribeAction(true);
        }


        private void Reg(PlayerMoveInput obj)
        {
            obj.Move += _mover.Move;
            obj.Jump += _mover.Jump;
            obj.Rotate += _cameraPlayer.Rotate;
            obj.Crouch += _crouchControl.SetState;
            obj.Run += _mover.SetRun;
        }

        private void Unreg(PlayerMoveInput obj)
        {
            obj.Move -= _mover.Move;
            obj.Jump -= _mover.Jump;
            obj.Rotate -= _cameraPlayer.Rotate;
            obj.Crouch -= _crouchControl.SetState;
            obj.Run -= _mover.SetRun;
        }
    }
}