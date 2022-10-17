using Plugins.MaoUtility.MaoExts.Static;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace.Cat
{
    public class CatMover : MonoBehaviour, ICatPart
    {
        [SerializeField]private Transform _root;

        [Button] public void Move(CatPoint point)
        {
            _root.transform.position = point.transform.position;
            _root.transform.rotation = point.transform.rotation;
        }

        public void MoveRandom(CatPoint[] points) => Move(points.GetRandom());
    }
}