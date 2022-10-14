#if HasAssets_Animacer
using Animancer;
#endif
#if HasAssets_DoTween

#endif
using UnityEngine;

#if HasAssets_UltEvents

#endif

namespace Plugins.MaoUtility.MaoExts.ExtAnimacer
{
    [AddComponentMenu("Mao Mono/Animacer Ext/Mono Clip Transition")]
    public class MonoClipTransition : MonoBehaviour
    {
        #if HasAssets_Animacer
        public AnimancerComponent AnimancerComponent;
        [Min(0)]public int Layer;
        public ClipTransition Clip;

        public UltEvent OnStart;
        public UltEvent OnEnd;
        public UltEvent OnStop;
        private AnimancerState _state;

        public AnimancerState State => _state;


        [ContextMenu("Play")]
        public void Play()
        {
            if(Clip==null)
                return;
            _state = AnimancerComponent.Layers[Layer].Play(Clip);
            if (_state != null)
            {
                OnStart.Invoke();
                _state.Events.OnEnd = ()=> OnEnd.Invoke();
            }
        }

        [ContextMenu("Stop")]
        public void Stop()
        {
            AnimancerComponent.Layers[Layer].GetOrCreateState(Clip).Stop();
            OnStop.Invoke();
        }
        
        public void Stop(float d)
        {
            var sta = AnimancerComponent.Layers[Layer].GetOrCreateState(Clip);
            DOTween.To(() => sta.Weight, x => sta.Weight=x, 0, d).OnComplete(() => { sta.Stop(); });
            OnStop.Invoke();
        }
        #endif
    }
}