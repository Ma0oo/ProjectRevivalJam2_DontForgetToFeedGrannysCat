using UnityEngine;

namespace Plugins.MaoUtility.MonoBehsGameHelper.ValueContainers
{
    [AddComponentMenu("Mao Mono/Value Container/Float Value Container")]
    public class FloatValueContainer : ValueContainer<float>
    {
        protected override float DefaultValid(float current, float min, float max) => Mathf.Clamp(current, min, max);
    }
}