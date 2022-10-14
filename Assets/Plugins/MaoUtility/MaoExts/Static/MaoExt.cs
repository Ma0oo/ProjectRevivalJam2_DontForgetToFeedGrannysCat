using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Plugins.MaoUtility.MaoExts.Static
{
    public static class MaoExt
    {
        // Enumerable

        public static T GetRandom<T>(this IEnumerable<T> collection)
        {
            var l = collection.ToList();
            return l[Random.Range(0, l.Count)];
        }

        // If

        public static T IsNull<T>(this T t, Action callback)
        {
            if (t == null) callback();
            return t;
        }

        public static T IsNotNull<T>(this T t, Action callback)
        {
            if (t != null) callback();
            return t;
        }
        
        public static T IsNull<T>(this T t, Action<T> callback)
        {
            if (t == null) callback(t);
            return t;
        }

        public static T IsNotNull<T>(this T t, Action<T> callback)
        {
            if (t != null) callback(t);
            return t;
        }

        public static T IfTrue<T>(this T t, Func<bool> validate, Action callback)
        {
            if (validate()) callback();
            return t;
        }

        public static T IfFalse<T>(this T t, Func<bool> validate, Action callback)
        {
            if (!validate()) callback();
            return t;
        }
        
        public static T IfTrue<T>(this T t, Func<bool> validate, Action<T> callback)
        {
            if (validate()) callback(t);
            return t;
        }

        public static T IfFalse<T>(this T t, Func<bool> validate, Action<T> callback)
        {
            if (!validate()) callback(t);
            return t;
        }

        // Spanw GO
        
        public static GameObject Spawn(this GameObject obj) => Object.Instantiate(obj, Vector3.zero, Quaternion.identity);
        public static GameObject Spawn(this GameObject obj, Vector3 pos) => Object.Instantiate(obj, pos, Quaternion.identity);
        public static GameObject Spawn(this GameObject obj, Vector3 pos, Quaternion quaternion) => Object.Instantiate(obj, pos, quaternion);
        public static GameObject Spawn(this GameObject obj, Transform transform) => Object.Instantiate(obj, transform);

        public static GameObject SpawnLocal(this GameObject obj, Transform transform, Vector3 pos) =>
            Object.Instantiate(obj, transform).With(x => x.transform.localPosition = pos);

        public static GameObject SpawnGlobal(this GameObject obj, Transform transform, Vector3 pos) =>
            Object.Instantiate(obj, transform).With(x => x.transform.position = pos);

        // Spawn by t where t is monobeh
        
        public static T Spawn<T>(this T obj) where T : Component => Object.Instantiate(obj, Vector3.zero, Quaternion.identity);
        public static T Spawn<T>(this T obj, Vector3 pos) where T : Component => Object.Instantiate(obj, pos, Quaternion.identity);
        public static T Spawn<T>(this T obj, Vector3 pos, Quaternion quaternion) where T : Component => Object.Instantiate(obj, pos, quaternion);
        public static T Spawn<T>(this T obj, Transform transform) where T : Component => Object.Instantiate(obj, transform);

        public static T SpawnLocal<T>(this T obj, Transform transform, Vector3 pos) where T : Component =>
            Object.Instantiate(obj, transform).With(x => x.transform.localPosition = pos);

        public static T SpawnGlobal<T>(this T obj, Transform transform, Vector3 pos) where T : Component =>
            Object.Instantiate(obj, transform).With(x => x.transform.position = pos);

        // Delete
        
        public static void DeleteComponent<T>(this T self) where T : MonoBehaviour => Object.Destroy(self);
        
        public static void DeleteComponent<T>(this T self, float delay) where T : MonoBehaviour => Object.Destroy(self, delay);

        public static void DeleteGO<T>(this T self) where T : MonoBehaviour => DeleteGO(self.gameObject);

        public static void DeleteGO<T>(this T self, float delay) where T : MonoBehaviour => DeleteGO(self.gameObject, delay);
        
        public static void DeleteGO(this GameObject self) => Object.Destroy(self);
        
        public static void DeleteGO(this GameObject self, float delay) => Object.Destroy(self, delay);

        // With

        public static T With<T>(this T self, Action<T> set)
        {
            set(self);
            return self;
        }

        
        public static T With<T>(this T self, Func<bool> when, Action<T> set)
        {
            if (when()) set(self);
            return self;
        }

        
        public static T With<T>(this T self, Action<T> set, Func<bool> when)
        {
            if (when()) set(self);
            return self;
        }

        public static T With<T>(this T self, Action<T> set, bool when)
        {
            if (when) set(self);
            return self;
        }
        
        public static T With<T>(this T self,bool when, Action<T> set)
        {
            if (when) set(self);
            return self;
        }
        
        // GetComponentOrCreate

        public static T GetComponentOrCreate<T>(this Component self) where T : Component => self.gameObject.GetComponentOrCreate<T>();
        
        public static T GetComponentOrCreate<T>(this Component self, bool withChildren = false) where T : Component => self.gameObject.GetComponentOrCreate<T>(withChildren);

        public static T GetComponentOrCreate<T>(this GameObject self) where T : Component
        {
            var result = self.GetComponent<T>();
            if (result) return result;
            return self.AddComponent<T>();
        }
        
        public static T GetComponentOrCreate<T>(this GameObject self, bool withChildren = false) where T : Component
        {
            if (withChildren)
            {
                var result = self.GetComponentInChildren<T>();
                if (result) return result;
                else return self.AddComponent<T>();
            }
            else
            {
                return self.GetComponentOrCreate<T>();
            }
        }

        public static bool InMyHierarchy(this Transform self, Transform target)
        {
            if (target == self) return true;
            var lastParent = target.parent;
            while (lastParent!=null)
            {
                if (lastParent == self) return true;
                lastParent = lastParent.parent;
            }

            return false;
        }
        
        public static bool InMyHierarchy(this Transform self, GameObject target) => self.InMyHierarchy(target.transform);
    }
}