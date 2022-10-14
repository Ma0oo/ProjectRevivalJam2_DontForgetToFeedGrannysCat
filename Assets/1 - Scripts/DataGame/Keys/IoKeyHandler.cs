using Plugins.MaoUtility.IoUi.Btns;
using Plugins.MaoUtility.IoUi.Core;
using Plugins.MaoUtility.MaoExts.Static;
using Sirenix.Utilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace DataGame.Keys
{
    public class IoKeyHandler : IoGroupHandler, IHideOpenIoBtn
    {
        [SerializeField] private IoBtnKey _keyView;
        [SerializeField] private Transform _parent;
         
        [HideInInspector] public IoBtnKey Forward;
        [HideInInspector] public IoBtnKey Back;
        [HideInInspector] public IoBtnKey Right;
        [HideInInspector] public IoBtnKey Left;
        [HideInInspector] public IoBtnKey Jump;
        [HideInInspector] public IoBtnKey Crouch;
        [HideInInspector] public IoBtnKey Run;
        [HideInInspector] public IoBtnKey Use;
        
        private MonoBehaviour[] Btns => new MonoBehaviour[]{Forward, Back, Right, Left, Jump, Crouch, Run, Use};

        private void Start()
        {
            SpawnIfNotExsit();
            Register<IoKeyHandler>();
        }

        private void SpawnIfNotExsit()
        {
            if(Forward) return;
            Forward = Spawn(nameof(Forward));
            Back = Spawn(nameof(Back));
            Right = Spawn(nameof(Right));
            Left = Spawn(nameof(Left));
            Jump = Spawn(nameof(Jump));
            Crouch = Spawn(nameof(Crouch));
            Run = Spawn(nameof(Run));
            Use = Spawn(nameof(Use));
        }

        private IoBtnKey Spawn(string forwardName)
        {
            var btn = _keyView.Spawn(_parent);
            btn.Component.Get<LabelIo>().Text = forwardName;
            return btn;
        }

        private void OnDestroy() => Unregister<IoKeyHandler>();
        public void On() => Btns.ForEach(x => x.gameObject.SetActive(true));

        public void Off() => Btns.ForEach(x => x.gameObject.SetActive(false));
    }
}