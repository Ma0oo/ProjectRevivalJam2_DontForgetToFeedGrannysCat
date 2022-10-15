using System;
using System.Linq;
using DefaultNamespace.ScenesLogic.Game;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace DataGame.Save
{
    [System.Serializable]
    public class SaveData
    {
        [JsonIgnore] public int Night => _night;
        [SerializeField,UnityEngine.Min(0), JsonProperty] private int _night;

        public void UpdateNight(Night lastPassNight, Night[] allNight)
        {
            _night = allNight.ToList().IndexOf(lastPassNight) + 1;
            _night = Mathf.Clamp(_night, 0, allNight.Length);
        }
    }
}