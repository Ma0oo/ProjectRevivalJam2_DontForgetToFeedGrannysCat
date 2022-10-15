using System;
using System.Linq;
using Plugins.MaoUtility.DataManagers;
using Sirenix.OdinInspector;

namespace DefaultNamespace.Player
{
    public class PlayerPartManager : DataManagerMonoBehByIntrerface<IPlayerUnitPart>
    {
        [Button]private void OnValidate() => Monos = GetComponentsInChildren<IPlayerUnitPart>().ToList();
    }
}