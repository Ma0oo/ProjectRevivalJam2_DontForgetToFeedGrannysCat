using System;
using System.Collections.Generic;
using DataGame.Keys;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.IoUi.Btns;
using Plugins.MaoUtility.IoUi.Core;
using Plugins.MaoUtility.Localization.Core;
using Plugins.MaoUtility.MaoExts.Static;
using Sirenix.Utilities;
using UnityEngine;

namespace DataGame.Sound
{
    [DiMark]
    public class IoSoundHandler : IoGroupHandler, IHideOpenIoBtn
    {
        [SerializeField] private IoBtnFloat _btnView;
        [SerializeField] private Transform _parent;

        [HideInInspector] public IoBtnFloat Master;
        [HideInInspector] public IoBtnFloat Effect;
        [HideInInspector] public IoBtnFloat Music;
        
        [DiInject] private Localizator _localizator;

        private List<Action> _actOnDestroy = new List<Action>();
        
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

        private IoBtnFloat Create(string nameField)
        {
            var r = _btnView.Spawn(_parent);
            _localizator.ChangeLanguage += OnChangeLand;
            _actOnDestroy.Add(()=>_localizator.ChangeLanguage -= OnChangeLand);
            OnChangeLand();
            return r;
            
            void OnChangeLand()
            {
                r.Component.Get<LabelIo>().SetTextById("KEY_"+nameField, "Установка имя поля для настроек в главном меню");    
            }
        }
        
        public void On() => Btns.ForEach(x => x.gameObject.SetActive(true));

        public void Off() => Btns.ForEach(x => x.gameObject.SetActive(false));
    }
}