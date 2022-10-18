using DefaultNamespace.Player;
using DefaultNamespace.Player.Inventory;
using DefaultNamespace.Player.View;
using Plugins.MaoUtility.MaoExts.Static;
using UnityEngine;

namespace DefaultNamespace.ItemSystem.ViewInUI
{
    public class ConnectPlayuerToViewInventory : BaseViewPlayerConnector
    {
        [SerializeField] private ViewInventory _viewInventory;
        
        protected override void OnInited(PlayerUnit obj) => obj.Parts.Get<IPlayerInventory>().IsNotNull(_viewInventory.Init);
    }
}