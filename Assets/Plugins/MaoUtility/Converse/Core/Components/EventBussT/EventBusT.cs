using System;
using System.Collections.Generic;
using Plugins.MaoUtility.AdvanceEvents;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Plugins.MaoUtility.Converse.Core.Components.EventBussT
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class EventBusT<T> : BaseConverseComponent
    {
        public override string PrefixAlias => $"Events[{TypeStr}]";

        public virtual string TypeStr => typeof(T).Name;

        [SerializeField] private Data<T>[] _datas;

        private Dictionary<string, Data<T>> Events => _events!=null ? _events : _events = CreateDict();
        private Dictionary<string, Data<T>> _events;

        private Dictionary<string, Data<T>> CreateDict()
        {
            var events = new Dictionary<string, Data<T>>();
            _datas.ForEach(x => events.Add(x.Name, x));
            return events;
        }

        [Button]
        public void Send(string nameEvent, T o) => Get(nameEvent).Invoke(o);

        public void Sub(string nameEvent, Action<T> callback) => Get(nameEvent).Sub(callback);

        public void Unsub(string nameEvent, Action<T> callback) => Get(nameEvent).Unsub(callback);

        private Data<T> Get(string name)
        {
            if (Events.ContainsKey(name)) return Events[name];
            else
            {
                var r = new Data<T>();
                Events.Add(name, r);
                return r;
            }
        }

        [System.Serializable]
        public class Data<Tdata>
        {
            public string Name;
            [SerializeField] private GroupEvent<Tdata> _event;

            public void Invoke(Tdata o) => _event.Invoke(o);

            public void Sub(Action<Tdata> callback) => _event.Sub(callback);
            
            public void Unsub(Action<Tdata> callback) => _event.Unsub(callback);
        }
    }
}