using System;
using System.Collections.Generic;
using Plugins.MaoUtility.AdvanceEvents;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Plugins.MaoUtility.Converse.Core.Components
{
    [RequireComponent(typeof(RectTransform))]
    public class EventBus : BaseConverseComponent
    {
        public override string PrefixAlias => "Events";

        [SerializeField] private Data[] _datas;

        private Dictionary<string, Data> Events => _events!=null ? _events : _events = CreateDict();
        private Dictionary<string, Data> _events;

        private Dictionary<string, Data> CreateDict()
        {
            var events = new Dictionary<string, Data>();
            _datas.ForEach(x => events.Add(x.Name, x));
            return events;
        }

        [Button]
        public void Send(string nameEvent) => Get(nameEvent).Invoke();

        public void Sub(string nameEvent, Action callback) => Get(nameEvent).Sub(callback);

        public void Unsub(string nameEvent, Action callback) => Get(nameEvent).Unsub(callback);

        private Data Get(string name)
        {
            if (Events.ContainsKey(name)) return Events[name];
            else
            {
                var r = new Data();
                Events.Add(name, r);
                return r;
            }
        }

        [System.Serializable]
        public class Data
        {
            public string Name;
            [SerializeField] private GroupEvent _event;

            public void Invoke() => _event.Invoke();

            public void Sub(Action callback) => _event.Sub(callback);
            
            public void Unsub(Action callback) => _event.Unsub(callback);
        }
    }
}