using Plugins.MaoUtility.MaoExts.Static;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.ItemSystem.ViewInUI
{
    public class ViewItemInUI : MonoBehaviour
    {
        [SerializeField] private Sprite _noImage;
        [SerializeField] private Image _imaged;
        
        public void Zero() => SetAplha(0);

        private void SetAplha(float a)
        {
            var imagedColor = _imaged.color;
            imagedColor.a = a;
            _imaged.color = imagedColor;
        }

        public void Init(Item item)
        {
            SetAplha(1);
            var cfg = item.Confgis.Get<ViewItemInUI_CFG>();
            if (cfg == null) _imaged.sprite = _noImage;
            else _imaged.sprite = cfg.Icon;
        }
        
        [System.Serializable]
        public class ViewItemInUI_CFG : ItemConfig
        {
            public Sprite Icon;
            
            public override object Clone()
            {
                return new ViewItemInUI_CFG();
            }
        }
    }
}