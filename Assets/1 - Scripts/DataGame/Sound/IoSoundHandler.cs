using DataGame.Keys;
using Plugins.MaoUtility.IoUi.Btns;
using Plugins.MaoUtility.IoUi.Core;
using Plugins.MaoUtility.MaoExts.Static;
using UnityEngine;

namespace DataGame.Sound
{
    public class IoSoundHandler : IoGroupHandler
    {
        [SerializeField] private IoBtnFloat _btnView;
        [SerializeField] private Transform _parent;

        public IoBtnFloat Master;
        public IoBtnFloat Effect;
        public IoBtnFloat Music;

        private void Awake()
        {
            Spawn();
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
    }
}