using System;
using Plugins.MaoUtility.InputModule.Core.BaseClasses;

namespace DefaultNamespace.Player.Inventory.HandView
{
    public interface IHandInput : IInput
    {
        public event Action<int> Select;
        public event Action DropSelected;
    }
}