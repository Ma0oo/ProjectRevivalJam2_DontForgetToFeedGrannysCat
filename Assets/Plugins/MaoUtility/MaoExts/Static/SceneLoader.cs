using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Plugins.MaoUtility.MaoExts.Static
{
    public static class SceneLoader
    {
        public static void Load(string name, Action onLoaded = null) =>
            CoroutineGame.Instance.StartCoroutine(LoadScene(name, onLoaded));

        public static void Restart(Action onLoad = null) => CoroutineGame.Instance.StartCoroutine(LoadScene(SceneManager.GetActiveScene().name, onLoad, true));

        private static IEnumerator LoadScene(string name, Action onLoaded = null, bool ignoreActiveScene = false)
        {
            if (SceneManager.GetActiveScene().name == name && !ignoreActiveScene)
            {
                onLoaded?.Invoke();
                yield break;
            }
            
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            while (!waitNextScene.isDone)
                yield return null;
            
            onLoaded?.Invoke();
        }
        
        #if UNITY_EDITOR
        [UnityEditor.MenuItem("Mao Tools/Fast restart scene")]
        private static void RestartSceneFromMenuItem() => Restart();
        #endif
    }
}
