using System.IO;
using DefaultNamespace;
using Plugins.MaoUtility.MaoExts.Static;
using Plugins.MaoUtility.SaveSystem.IO;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DataGame
{
    public class DataProvider : MonoBehaviour
    {
        [ShowInInspector]private DataSetting _dataSetting;

        public DataSetting DataSettingCurrent
        {
            get
            {
                if(_dataSetting==null) Load();
                return _dataSetting;
            }
        }
        
        private SaverJSONtoPlayerPrefs _saver = new SaverJSONtoPlayerPrefs();

        private string PathData => Path.Join(Application.dataPath, "Save/Setting.json");

        [Button]public void Load()
        {
            var Result = _saver.Load<DataSetting>(PathData);
            if (Result == null)
            {
                DefaultLoad();
                return;
            }
            else
            {
                _dataSetting = Result;
            }
            
            void DefaultLoad()
            {
                _dataSetting = ConfigGame.Instance.DefaultSetting;
                Save();
            }
        }
        
        [Button]public void Save()
        {
            if(_dataSetting==null) return;
            _saver.Save(_dataSetting, PathData);
        }
    }
}