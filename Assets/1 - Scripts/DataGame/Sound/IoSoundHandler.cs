using DataGame.Keys;
using Plugins.MaoUtility.IoUi.Btns;
using Plugins.MaoUtility.IoUi.Core;
using Plugins.MaoUtility.MaoExts.Static;
using Sirenix.Utilities;
using UnityEngine;

namespace DataGame.Sound
{
    public class IoSoundHandler : IoGroupHandler, IHideOpenIoBtn
    {
        [SerializeField] private IoBtnFloat _btnView;
        [SerializeField] private Transform _parent;

        [HideInInspector] public IoBtnFloat Master;
        [HideInInspector] public IoBtnFloat Effect;
        [HideInInspector] public IoBtnFloat Music;
        
        private MonoBehaviour[] Btns => new MonoBehaviour[]{Master, Effect, Music};

        private void Start()
        {
            Spawn();
            Register<IoSoundHandler>();
        }

        private void Spawn()
        {
            Master = Create(nameof(Master));
            Effect = Create(nameof(Effect));
            Music = Create(nameof(Music));
        }

        private IoBtnFloat Create(string masterName)
        {
            var r = _btnView.Spawn(_parent);
            r.Component.Get<LabelIo>().Text = masterName;
            return r;
        }
        
        public void On() => Btns.ForEach(x => x.gameObject.SetActive(true));

        public void Off() => Btns.ForEach(x => x.gameObject.SetActive(false));
    }
}