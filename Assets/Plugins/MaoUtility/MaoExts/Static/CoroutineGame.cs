using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Plugins.MaoUtility.MaoExts.Static
{
    public class CoroutineGame : MonoBehaviour
    {
        public static CoroutineGame Instance
        {
            get
            {
                if (_instance) return _instance;
                Create();
                return _instance;
            }
        }
        private static CoroutineGame _instance;

        private Dictionary<string, Coroutine> _waitActions = new Dictionary<string, Coroutine>();

        private void Awake()
        {
            if(Application.isPlaying) DontDestroyOnLoad(gameObject);
            if (_instance) Destroy(gameObject);
            else _instance = this;
        }

        private static void Create()
        {
            var objectCor = new GameObject(nameof(CoroutineGame));
            objectCor.AddComponent<CoroutineGame>().ClearSceneByMe();
        }

        public void StopWait(string id)
        {
            if(_waitActions.TryGetValue(id, out var r)) StopCoroutine(r);
        }

        public string WaitFrame(int count, Action callback)
        {
            var guid = Guid.NewGuid().ToString();
            _waitActions.Add(guid, StartCoroutine(WaitFrameCoroutine(count, callback, guid)));
            return guid;
        }

        public string Wait(float time, Action callback)
        {
            var guid = Guid.NewGuid().ToString();
            _waitActions.Add(guid, StartCoroutine(WaitSecondCoroutine(time, callback, guid)));
            return guid;
        }

        private IEnumerator WaitSecondCoroutine(float time, Action callback, string myId)
        {
            if (time < 0) time = 0;
            yield return new WaitForSeconds(time);
            callback.Invoke();
            _waitActions.Remove(myId);
        }

        private IEnumerator WaitFrameCoroutine(int count, Action callback, string myId)
        {
            if (count <= 0) count = 1;
            for (int i = 0; i < count; i++)
            {
                yield return null;
            }
            callback.Invoke();
            _waitActions.Remove(myId);
        }

        public void WaitLoop(Func<bool> func, Action action, float waitTime)
        {
            if (func()) action();
            else Wait(waitTime, ()=>WaitLoop(func, action, waitTime));
        }

        [Button]
        private void ClearSceneByMe()
        {
            if(Application.isPlaying) return;
            
            IEnumerable<CoroutineGame> l = FindObjectsOfType<CoroutineGame>();
            l = l.Except(new[] {this}).ForEach(x => DestroyImmediate(x.gameObject));
        }
    }
}
