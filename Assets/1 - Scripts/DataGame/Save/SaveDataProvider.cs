using System;
using System.IO;
using DefaultNamespace;
using Plugins.MaoUtility.SaveSystem.IO;
using ScenesLogic.Menu;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DataGame.Save
{
    public class SaveDataProvider : MonoBehaviour
    {
        public SaveData Current {
            get
            {
                if (_current != null) return _current;
                Load();
                return _current;
            }
        }
        [ShowInInspector]private SaveData _current;
        
        private SaverJSONtoPlayerPrefs _saver = new SaverJSONtoPlayerPrefs();

        private void Start()
        {
            SettingPanelMenu.ClearAllProgress += OnClear;
        }

        private void OnClear()
        {
            _current = new SaveData();
            Save();
            Load();
        }

        private string PathData => Path.Join(Application.dataPath, "Save/Progress.json");

        [Button]public void Load()
        {
            var Result = _saver.Load<SaveData>(PathData);
            if (Result == null)
            {
                DefaultLoad();
                return;
            }
            else
            {
                _current = Result;
            }
            
            void DefaultLoad()
            {
                _current = ConfigGame.Instance.DefaultProgress;
                Save();
            }
        }

        [Button]public void Save()
        {
            if(_current==null) return;
            _saver.Save(_current, PathData);
        }

        private void OnDestroy()
        {
            Save();
            SettingPanelMenu.ClearAllProgress -= OnClear;
        }
    }
}