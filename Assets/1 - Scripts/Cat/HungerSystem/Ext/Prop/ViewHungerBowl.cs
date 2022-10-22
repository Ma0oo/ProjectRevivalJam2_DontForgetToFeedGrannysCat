using DefaultNamespace.ItemSystem;
using DefaultNamespace.ItemSystem.EventBuss;
using DefaultNamespace.ItemSystem.Inventory;
using DefaultNamespace.Player.Inventory.HandView.ExtInterect;
using DefaultNamespace.PropSystem;
using UnityEngine;

namespace DefaultNamespace.Cat.HungerSystem.Ext.Prop
{
    public class ViewHungerBowl : MonoBehaviour, IPropPart
    {
        private IHungerControl _hungerControl;

        [SerializeField] private float _minYPos;
        [SerializeField] private float _maxYPos;
        [SerializeField] private Transform _targetObjectView;
        [SerializeField] private ExtHandInterectObjeect _interect;

        public void Init(IHungerControl hungerControl)
        {
            _hungerControl = hungerControl;
            _hungerControl.Stat.Changed += OnChanged;
            _interect.Used.DynamicCalls += TryUseItem;
        }

        private void TryUseItem(Item obj)
        {
            var foodData = obj.Confgis.Get<FoodDataItemConfig>();
            if(foodData==null) return;
            _hungerControl.Stat.Current += foodData.AddFood;
            obj.Confgis.Get<ItemEventBus>().BusE.Post(new InventoryBase.RemoveItemEvent());
        }

        private void OnChanged()
        {
            var y = Mathf.Lerp(_minYPos, _maxYPos, _hungerControl.Stat.Current / _hungerControl.Stat.Max);
            var pos = _targetObjectView.localPosition;
            pos.y = y;
            _targetObjectView.localPosition = pos;
        }
        
        [System.Serializable]
        public class FoodDataItemConfig : ItemConfig
        {
            public float AddFood;
            
            public override object Clone()
            {
                var r = new FoodDataItemConfig();
                r.AddFood = AddFood;
                return r;
            }
        }
    }
}