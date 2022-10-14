using Plugins.MaoUtility.MonoBehsGameHelper;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DoorSystem
{
    [CreateAssetMenu(menuName = "Configs/Editor/Door")]
    public class DoorConfig : ConfigSo<DoorConfig>
    {
        public float HLine=2;
        public Color ColorLine = Color.red;
        
        public float HHandler=2;
        public Color ColorEditorBtnConnect = Color.red;
        public Color ColorEditorBtnDisconnect = Color.blue;
        public float SizeEditBtn = 0.7f;
        
        public Color ColorSelect = Color.green;
        public float SizeSelect=0.4f;

        [ShowInInspector] private static bool ShowAllways
        {
            get => ShowAllwaysGizmos;
            set => ShowAllwaysGizmos = value;
        }
        public static bool ShowAllwaysGizmos;
    }
}