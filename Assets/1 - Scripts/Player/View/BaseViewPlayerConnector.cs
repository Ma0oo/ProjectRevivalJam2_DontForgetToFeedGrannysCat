using UnityEngine;

namespace DefaultNamespace.Player.View
{
    public abstract class BaseViewPlayerConnector : MonoBehaviour
    {
        [SerializeField] private ViewPlayerReciver _viewReciver;
        

        private void Start() => _viewReciver.Inited.SubAndInvoke(OnInited);

        protected abstract void OnInited(PlayerUnit obj);
    }
}