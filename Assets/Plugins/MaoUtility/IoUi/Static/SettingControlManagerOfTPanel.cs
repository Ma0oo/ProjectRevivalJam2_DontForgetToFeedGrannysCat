using System;
using System.Collections.Generic;
using System.Linq;
using Plugins.MaoUtility.IoUi.Core;
using Sirenix.Utilities;
using UnityEngine;

namespace Plugins.MaoUtility.IoUi.Static
{
    public static class SettingControlManagerOfTPanel
    {
        private static Dictionary<Type, ConnectorTypeForManager> _connectors;
        
        public static Type GetTypeByTPanel<T>() where T : IoGroupHandler
        {
            if (_connectors == null) Init();
            if (_connectors.TryGetValue(typeof(T), out var r))
                return r.GetTypeIniter();
            
            Debug.LogError("!!!!!!!!!!");
            throw new Exception($"Нет класса конетктора для поиска настроект");
        }

        private static void Init()
        {
            _connectors=new Dictionary<Type, ConnectorTypeForManager>();
            var typeBaseConnector = typeof(ConnectorTypeForManager);
            AppDomain.CurrentDomain.GetAssemblies().ForEach(x =>
            {
                x.GetTypes()
                    .Where(x => x.IsSubclassOf(typeBaseConnector) && !x.IsAbstract && x.IsClass)
                    .ForEach(x =>
                    {
                        ConnectorTypeForManager newConnector = Activator.CreateInstance(x) as ConnectorTypeForManager;
                        _connectors.Add(newConnector.TargetTypeHandler, newConnector);
                    });
            });
        }
    }
}