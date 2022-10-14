﻿using System;
using System.Collections.Generic;
using System.Linq;
using Plugins.MaoUtility.Converse.Interfaces;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Plugins.MaoUtility.Converse.Core
{
    public class ConversePanel : UIBehaviour, IManagerMarkType<IConverseMarkType>
    {
        private IConverseMarkType[] _components;
        private IConverseMarkType[] Components => _components != null ? _components : _components = GetComponentsMarksType();

        [InfoBox("Будет изменено при спауне из создателя")]
        [SerializeField]private string _name;

        public string Name => _name;

        private IConverseMarkType[] GetComponentsMarksType()
        {
            var otherPanel = GetComponentsInChildren<ConversePanel>().Except(new[] {this});
            IEnumerable<IConverseMarkType> _tempComponents = GetComponentsInChildren<IConverseMarkType>();
            otherPanel.ForEach(x => _tempComponents = _tempComponents.Except(x.Components));
            return (_components = _tempComponents.ForEach(x => x.Init(this)).ToArray());
        }

        public void Init(string s) => _name = s;
        
        public IMarkType GetID(string id) => Components.FirstOrDefault(x => x.ID == id);
        
        public Tm GetCastByAlias<Tm>(string alias) where Tm : class, IConverseMarkType
        {
            if (alias == null || string.IsNullOrWhiteSpace(alias)) alias = "";
            return Components.FirstOrDefault(x =>
            {
                if (x is Tm) return ((Tm) x).Alias == alias;
                return false;
            }) as Tm;
        }

        public Tm[] GetAllCastByAlias<Tm>(string alias) where Tm : class, IConverseMarkType =>
            Components.Where(x =>
            {
                if (x is Tm) return ((Tm) x).Alias == alias;
                return false;
            }).Cast<Tm>().ToArray();

        public Tm GetCast<Tm>() where Tm : class, IConverseMarkType => Components.FirstOrDefault(x => x is Tm) as Tm;

        public Tm[] GetAllCast<Tm>() where Tm :class,  IConverseMarkType => Components.Where(x => x is Tm).Cast<Tm>().ToArray();

        public Tm GetPredict<Tm>(Func<Tm, bool> predict) where Tm :class,  IConverseMarkType =>
            Components.FirstOrDefault(x =>
            {
                if (x is Tm) return predict(x as Tm);
                else return false;
            }) as Tm;

        public Tm[] GetPredictAll<Tm>(Func<Tm, bool> predict) where Tm :class,  IConverseMarkType
        {
            return Components.Where(x =>
            {
                if (x is Tm) return predict(x as Tm);
                else return false;
            }).Cast<Tm>().ToArray();
        }
    }
}