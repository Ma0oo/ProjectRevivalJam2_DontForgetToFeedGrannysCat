using System;
using DataGame.Keys;
using DataGame.Sound;
using DoorSystem;
using Newtonsoft.Json;
using Plugins.MaoUtility.AdvanceEvents.EventsBus;
using Plugins.MaoUtility.Converse.Core.Components.EventBussT;

namespace DataGame
{
    [System.Serializable]
    public class DataSetting 
    {
        [JsonIgnore]public EventBusLimited<Event> Bus => _bus;
        [JsonIgnore]private EventBusLimited<Event> _bus = new EventBusLimited<Event>();

        public KeyConfig Keys;
        public SoundConfig SoundConfig;
        
        public abstract class Event { }
        
        public class DataUpdated : Event { }
    }
}