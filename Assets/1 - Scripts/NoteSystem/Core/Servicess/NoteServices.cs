using Plugins.MaoUtility.InputModule.AutoSub;
using Plugins.MaoUtility.MaoExts.Static;
using Plugins.MaoUtility.SM;
using UnityEngine;

namespace DefaultNamespace.NoteSystem
{
    public class NoteServices : MonoBehaviour
    {
        public IClosedSM<NoteState> SM=>_sm;
        [SerializeField] private StateMachine _sm=new StateMachine();

        private SubInputClass<InputNote> _sub;

        public bool IsShowNote => _sm.Current.GetType() == typeof(NoteContetn);

        private void Start()
        {
            _sub = new SubInputClass<InputNote>(x => x.Close += OnClose, x => x.Close -= OnClose);
        }

        public void ViewNewNote(string keyNote)
        {
            _sm.ChangeTo(new NoteContetn(keyNote));
            _sub.SubscribeAction(true);
        }

        private void OnClose()
        {
            _sub.SubscribeAction(false);
            CoroutineGame.Instance.WaitFrame(1, ()=>_sm.ChangeTo(new NoNote()));
        }

        [System.Serializable]
        public class StateMachine : SmByClass<NoteState>
        {
            public override bool ValidChange(NoteState oldState, NoteState newState) 
                => oldState.GetType() != newState.GetType();
        }
    }
}