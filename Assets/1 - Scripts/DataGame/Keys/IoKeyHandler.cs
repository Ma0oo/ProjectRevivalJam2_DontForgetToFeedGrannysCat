using System;
using System.Collections.Generic;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.IoUi.Btns;
using Plugins.MaoUtility.IoUi.Core;
using Plugins.MaoUtility.Localization.Core;
using Plugins.MaoUtility.MaoExts.Static;
using Sirenix.Utilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace DataGame.Keys
{
    [DiMark]
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
        
        [HideInInspector] public IoBtnKey FirstItem;
        [HideInInspector] public IoBtnKey SecondItem;
        [HideInInspector] public IoBtnKey ThirdItem;
        [HideInInspector] public IoBtnKey FourtedItem;
        [HideInInspector] public IoBtnKey FiftenItem;
        [HideInInspector] public IoBtnKey DropItem;
        [HideInInspector] public IoBtnKey CloseNote;
        [HideInInspector] public IoBtnKey MenuGame;

        [DiInject] private Localizator _localizator;

        private List<Action> _actOnDestroy = new List<Action>();

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

            FirstItem = Spawn(nameof(FirstItem));
            SecondItem = Spawn(nameof(SecondItem));
            ThirdItem = Spawn(nameof(ThirdItem));
            FourtedItem = Spawn(nameof(FourtedItem));
            FiftenItem = Spawn(nameof(FiftenItem));
            DropItem = Spawn(nameof(DropItem));
            CloseNote = Spawn(nameof(CloseNote));
            MenuGame = Spawn(nameof(MenuGame));
        }

        private IoBtnKey Spawn(string nameField)
        {
            var btn = _keyView.Spawn(_parent);
            _localizator.ChangeLanguage += OnChangeLand;
            _actOnDestroy.Add(()=>_localizator.ChangeLanguage -= OnChangeLand);
            OnChangeLand();
            return btn;

            void OnChangeLand()
            {
                btn.Components.Get<LabelIo>().SetTextById("KEY_"+nameField, "Установка имя поля для настроек в главном меню");    
            }
        }

        private void OnDestroy()
        {
            Unregister<IoKeyHandler>();
            _actOnDestroy.ForEach(x => x.Invoke());
        }

        public void On() => Btns.ForEach(x => x.gameObject.SetActive(true));

        public void Off() => Btns.ForEach(x => x.gameObject.SetActive(false));
    }
}