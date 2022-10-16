using System;
using DefaultNamespace.ScenesLogic.Game;
using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.MaoExts.Static;
using Plugins.MaoUtility.SceneFlow;
using Unity.VisualScripting;
using UnityEngine;

namespace DataGame.Keys
{
    public abstract class BaseViewGameTime : MonoBehaviour
    {
        protected OwnerSceneLogic Owner => _ownerSceneLogic ??= DI.Instance.Get<OwnerSceneLogic>();
        private OwnerSceneLogic _ownerSceneLogic;

        protected GameTime Time => Owner.Get<GameTime>();

        private void Start()
        {
            if(Time==null) return;
            CoroutineGame.Instance.WaitFrame(2, Init);
        }

        private void Init()
        {
            Time.NewNormal +=()=> OnNewNormal(Time.Normal);
            Time.HourPass += () => OnNewHours(Time.CurrentHours);
            Time.AllHourPass += OnEnd;
            
            OnNewHours(Time.CurrentHours);
            OnNewNormal(Time.Normal);
        }
        
        protected virtual void CustomStart(){}

        protected virtual void OnEnd() { }

        protected abstract void OnNewNormal(float normal);
        
        protected abstract void OnNewHours(Night.HourData hour);
    }
}