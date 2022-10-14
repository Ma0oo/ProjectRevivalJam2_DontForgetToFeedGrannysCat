using System.Collections.Generic;
using System.Linq;
using Plugins.MaoUtility.MaoExts.Static;
using Sirenix.Utilities;
using UnityEngine;

namespace Plugins.MaoUtility.Converse.Core.Components
{
    public class GroupPanel : BaseConverseComponent
    {
        public override string PrefixAlias => "Group";

        private Dictionary<string, ConversePanel> _panels = new Dictionary<string, ConversePanel>();

        private void Awake() => Init();

        public void Init()
        {
            _panels.Clear();
            var panels = GetComponentsInChildren<ConversePanel>();
            GetComponent<ConversePanel>().IsNotNull(x => panels = panels.Except(new[] {x}).ToArray());;
            panels.ForEach(x =>
            {
                if(_panels.ContainsKey(x.Name)) Debug.LogWarning($"{x.Name} - дубликат именеи здесь (клик на меня)", this);
                else _panels.Add(x.Name, x);
            });
        }

        public ConversePanel GetPanelOrNull(string name)
        {
            if (_panels.ContainsKey(name)) return _panels[name];
            
            Debug.LogError($"Не имею панель с данным именем - {name}", this);
            return null;
        }
    }
}