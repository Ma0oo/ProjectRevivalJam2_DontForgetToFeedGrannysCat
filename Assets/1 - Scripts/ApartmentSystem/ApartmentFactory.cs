using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.MaoExts.Static;
using UnityEngine;

namespace DefaultNamespace.ApartmentSystem
{
    public class ApartmentFactory : MonoBehaviour
    {
        public Apartment App => _app;
        private Apartment _app;
        
        public void Init(Apartment app)
        {
            if (_app) return;
            app.gameObject.SetActive(false);
            _app = app.Spawn();
            app.gameObject.SetActive(true);
            _app.gameObject.InjectGO(DI.Instance);
            _app.gameObject.SetActive(true);
        }
    }
}