using Plugins.MaoUtility.MonoBehsGameHelper;
using UnityEngine;

namespace DefaultNamespace.Cat
{
    [CreateAssetMenu(menuName = "Configs/Cat", order = 51)]
    public class CatConfig : ConfigSo<CatConfig>
    {
        public Mesh HeadCatModel;
    }
}