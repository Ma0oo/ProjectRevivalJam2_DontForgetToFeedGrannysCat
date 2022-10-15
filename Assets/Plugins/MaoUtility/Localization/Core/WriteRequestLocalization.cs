using System.Collections.Generic;
using System.IO;
using Plugins.MaoUtility.Localization.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Plugins.MaoUtility.Localization.Implementation.MaoLocal
{
    public class WriteRequestLocalization
    {
        private string _nameFile;
        private List<string> _logs;

        private int _countLog;
        
        public WriteRequestLocalization(int count) => Init(count);
        
        public WriteRequestLocalization() => Init(100);

        private void Init(int count)
        {
            var time = System.DateTime.Now;
            _nameFile = $"Log local M{time.Month}-D{time.Day}=H{time.Hour}-M{time.Minute}-S{time.Second}.txt";
            if(_logs!=null) _logs.Clear();
            else _logs = new List<string>();
            _countLog = count < 100 ? 100 : count;
        }

        public void AddLog(string id, string mes)
        {
            if(!LocalizationConfig.Instance.WriteRequest) return;
            _logs.Add($"{id} | scene {SceneManager.GetActiveScene().name} | (\"{id}\":\"NewValue\")\n" +
                      $"{mes}\n");
            if (_logs.Count > _countLog) Save();
        }

        public void Save()
        {
            var cfg = LocalizationConfig.Instance;
            if(!cfg.WriteRequest || _logs.Count==0) return;
            
            string path = "";
            path = cfg.PathByAssets ? Path.Join(Application.dataPath, cfg.PathToWrite) : cfg.PathToWrite;
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            
            var pathFile = Path.Join(path, _nameFile);
            if(!File.Exists(pathFile)) 
                File.Create(pathFile).Dispose();
            
            File.WriteAllLines(pathFile, _logs);
            Init(_countLog);
        }
    }
}