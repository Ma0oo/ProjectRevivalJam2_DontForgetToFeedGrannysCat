using System.Collections.Generic;
using System.Linq;
using Plugins.MaoUtility.SceneFlow;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace DefaultNamespace.ScenesLogic.Game
{
    public class GameTimeEvents : SceneLogic
    {
        [SerializeField, ReadOnly]private List<ActionByGameTime> _acts=new List<ActionByGameTime>();
        
        private GameTime GameTime => Owner.Get<GameTime>();

        public void Start()
        {
            GameTime.NewNormal += OnNewNormal;
            GameTime.AllHourPass += OnEnd;
        }

        private void OnEnd()
        {
            GameTime.NewNormal -= OnNewNormal;
            GameTime.AllHourPass -= OnEnd;
        }

        private void OnNewNormal()
        {
            var collection = _acts.Where(x => x.TryAct(GameTime.CurrentHours.Hour, GameTime.NormalHours));
            if(collection.Count()>0)
            {
                collection.ForEach(x => x.Evnting());
                _acts = _acts.Except(collection).ToList();
            }
        }

        public void Add(ActionByGameTime action)
        {
            if(!_acts.Contains(action))
                _acts.Add(action);
        }
    }
}