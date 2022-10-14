using UnityEngine;

namespace Plugins.MaoUtility.MonoBehsGameHelper.ValueContainers
{
    [AddComponentMenu("Mao Mono/Value Container/Int Value Container")]
    public class IntValueContainer : ValueContainer<int>
    {
        protected override int DefaultValid(int current, int min, int max) => Mathf.Clamp(current, min, max);
    }
}