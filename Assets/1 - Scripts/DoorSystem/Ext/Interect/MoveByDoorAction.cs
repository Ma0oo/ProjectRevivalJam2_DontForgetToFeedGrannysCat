using Player.Controlls;
using Plugins.MaoUtility.InterectSystem.Core.BasesClasses;

namespace DoorSystem.Ext.Interect
{
    public class MoveByDoorAction : InterectActionBase
    {
        public DoorMoveEntity MoveObj;

        public MoveByDoorAction(DoorMoveEntity entity) => MoveObj = entity;
    }
}