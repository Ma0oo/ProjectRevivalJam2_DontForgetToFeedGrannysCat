using System;
using Newtonsoft.Json;
using Plugins.MaoUtility.DataManagers;
using Sirenix.Utilities;
using UnityEngine;

namespace Plugins.MaoUtility.CustonObject.Core
{
    [System.Serializable]
    public abstract class ComplexObject<CONFIG, DATA> : ICloneable where CONFIG : class, ICloneable where DATA : class, ICloneable
    {
        [JsonIgnore] public string Id => _id;
        [SerializeField, JsonProperty] private string _id;

        public abstract DataManagerSystemObject<CONFIG> Config { get; protected set; }
        public abstract DataManagerSystemObject<DATA> Datas { get; protected set; }
        
        public object Clone()
        {
            var r = (ComplexObject<CONFIG, DATA>) Activator.CreateInstance(GetType());
            r._id = Id;
            r.Config = Config.Clone();
            r.Datas = Datas.Clone();
            return r;
        }

        public virtual object Clone(DATA[] datas)
        {
            var r = (ComplexObject<CONFIG, DATA>)Clone();
            r.Datas.GetAll(x => true).ForEach(x => r.Datas.Remove(x));
            datas.ForEach(x => r.Datas.Add(x));
            return r;
        }
    }
}