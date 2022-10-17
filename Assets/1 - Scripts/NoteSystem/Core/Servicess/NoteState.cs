using System.Xml;
using Player.Controlls;
using Plugins.MaoUtility.SM;
using Sirenix.OdinInspector.Modules.UnityMathematics.Editor;

namespace DefaultNamespace.NoteSystem
{
    public abstract class NoteState : IStateSm
    {
        public abstract void Enter();
        public abstract void Exit();
    }
}