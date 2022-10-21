using DefaultNamespace.PropSystem;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.InterectSystem.Implementation.OneceInterect;
using UnityEngine;

namespace DefaultNamespace.NoteSystem
{
    [DiMark]
    public class Note : MonoBehaviour, IPropPart
    {
        [SerializeField] private OnceInterectObject _interectObject;
        [SerializeField] private string _keyNote;

        [DiInject] private NoteServices _noteServices;

        private void Start() => _interectObject.Clicked += OnClicked;

        private void OnClicked() => _noteServices.ViewNewNote(_keyNote);

        public void Init(string noteKey) => _keyNote = noteKey;
    }
}