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
            CustomStart();
        }

        private void Init()
        {
            Time.NewNormal +=OnTimeOnNewNormal;
            Time.HourPass += OnTimeOnHourPass;
            Time.AllHourPass += OnEnd;
            
            OnNewHours(Time.CurrentHours);
            OnNewNormal(Time.Normal);
            Time.AllHourPass += Stop;
        }

        private void OnTimeOnHourPass() => OnNewHours(Time.CurrentHours);

        private void OnTimeOnNewNormal() => OnNewNormal(Time.Normal);

        private void Stop()
        {
            Time.NewNormal -= OnTimeOnNewNormal;
            Time.HourPass -= OnTimeOnHourPass;
            Time.AllHourPass -= OnEnd;
        }

        protected virtual void CustomStart(){}

        protected virtual void OnEnd() { }

        protected abstract void OnNewNormal(float normal);
        
        protected abstract void OnNewHours(Night.HourData hour);
    }
}