namespace DefaultNamespace.NoteSystem
{
    public class NoteContetn : NoteState
    {
        public string KeyContent { get; private set; }
        
        public NoteContetn(string keyContent) => KeyContent = keyContent;

        public override void Enter() { }

        public override void Exit() { }
    }
}