using UnityEngine;

namespace Plugins.MaoUtility.InterectSystem.Core.BasesClasses
{
    public abstract class BaseInterector : MonoBehaviour
    {
        [SerializeField] private bool _searchObjInChildByRb;

        public InterectObject TryGetInterectObj(Collider collider)
        {
            if (!collider) return null;
            if (collider.attachedRigidbody)
            {
                if (_searchObjInChildByRb)
                {
                    var r = collider.attachedRigidbody.GetComponentInChildren<InterectObject>();
                    if (r) return r;
                }
                else
                {
                    var r = collider.attachedRigidbody.GetComponent<InterectObject>();
                    if (r) return r;
                }
            }

            return collider.GetComponent<InterectObject>();
        }
    }
}