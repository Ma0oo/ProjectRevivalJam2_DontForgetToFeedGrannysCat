using Plugins.MaoUtility.InterectSystem.Core;
using Plugins.MaoUtility.InterectSystem.Core.BasesClasses;
using UnityEngine;

namespace Plugins.MaoUtility.InterectSystem.Implementation.RayView
{
    public class RayViewInterect : BaseInterector
    {
        [SerializeField] private Transform _point;
        [SerializeField] private float _lenght;
        [SerializeField] private LayerMask _mask;

        private InterectObject _currentView;

        private void FixedUpdate() => OnInterect();

        private void OnInterect()
        {
            Ray ray = new Ray(_point.transform.position, _point.transform.forward);
            if (Physics.Raycast(ray, out var info, _lenght, _mask))
            {
                var objInterect = TryGetInterectObj(info.collider);
                if (objInterect != _currentView)
                {
                    _currentView?.Interect(new RayAction(false));
                    _currentView = objInterect;
                    _currentView?.Interect(new RayAction(true));                    
                }
            }
        }
    }
}