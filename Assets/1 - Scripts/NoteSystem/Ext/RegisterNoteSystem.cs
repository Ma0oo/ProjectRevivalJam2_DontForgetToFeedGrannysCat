using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.DILocator.Core.BaseClasses;
using UnityEngine;

namespace DefaultNamespace.NoteSystem
{
    public class RegisterNoteSystem : RegisterDI
    {
        [SerializeField]private NoteServices _noteServices;
         
        protected override void Register(DI di) => di.Set(_noteServices);

        protected override void Unregister(DI di) => di.Remove<NoteServices>();
    }
}