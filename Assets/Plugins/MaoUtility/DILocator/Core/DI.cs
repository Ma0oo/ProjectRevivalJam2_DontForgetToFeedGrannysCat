using System;
using System.Collections.Generic;
using System.Reflection;
using Plugins.MaoUtility.DILocator.Atr;
using UnityEngine;

namespace Plugins.MaoUtility.DILocator.Core
{
    public class DI
    {
        public const string DefaultId = "Default";
        
        private TypeGroup _dis = new TypeGroup();
        public TypeGroup Data => _dis;

        private static DI _instance;
        public static DI Instance => _instance ??= new DI();

        public void Set<T>(T target, object id) => _dis.GetOrCreate(typeof(T)).Set(target, id);
        public void Remove<T>(object id) => _dis.GetOrCreate(typeof(T)).Remove(id);
        public T Get<T>(object id) => _dis.GetOrCreate(typeof(T)).Get<T>(id);

        public bool Has<T>() => _dis.HasType(typeof(T));

        public bool Has<T>(object id)
        {
            if (Has<T>()==false) return false;
            return _dis.GetOrCreate(typeof(T)).HasID(id);
        }

        public T GetOrCreate<T>() where T : new()
        {
            if (Has<T>()) return Get<T>();
            else
            {
                T r = new T();
                Set<T>(r);
                return r;
            }
        }
        
        public T GetOrCreate<T>(object id) where T : new()
        {
            if (Has<T>(id)) return Get<T>(id);
            else
            {
                T r = new T();
                Set<T>(r, id);
                return r;
            }
        }

        public void Set<T>(T target) => Set(target, DefaultId);
        public void Remove<T>() => Remove<T>(DefaultId);
        public T Get<T>() => Get<T>(DefaultId);

        public void RemoveAll() => _dis.Clear();

        public object Get(Type t, object id) => _dis.GetOrCreate(t).Get(id, t);
        public object Get(Type t) => Get(t, DefaultId);

        public void Inject(object target)
        {
            var targetType = target.GetType();
            var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy;
            foreach (var fieldInfo in targetType.GetFields(flags))
            {
                var atr = fieldInfo.GetCustomAttribute<DiInject>();
                if(atr==null) continue;
                fieldInfo.SetValue(target, Get(fieldInfo.FieldType, atr.ID));
            }
            foreach (var propertyInfo in targetType.GetProperties(flags))
            {
                if(propertyInfo.CanWrite==false) continue;
                var atr = propertyInfo.GetCustomAttribute<DiInject>();
                if(atr==null) continue;
                propertyInfo.SetValue(target, Get(propertyInfo.PropertyType, atr.ID));
            }
            foreach (var methodInfo in targetType.GetMethods(flags))
            {
                var atr = methodInfo.GetCustomAttribute<DiInject>();
                if(atr==null) continue;
                var paramsType = methodInfo.GetParameters();
                if (paramsType.Length == 0)
                {
                    methodInfo.Invoke(target, new object[0]);
                }
                else
                {
                    var par = new object[paramsType.Length];
                    for (int i = 0; i < paramsType.Length; i++)
                    {
                        var atrParam = paramsType[i].GetCustomAttribute<DiInject>();
                        par[i] = Get(paramsType[i].ParameterType, atrParam == null ? DefaultId : atrParam.ID);
                    }
                    methodInfo.Invoke(target, par);
                }
            }
        }

        public class TypeGroup : Dictionary<Type, DictIdObj>
        {
            public bool HasType(Type t) => ContainsKey(t);

            public DictIdObj GetOrCreate(Type t)
            {
                if (HasType(t)) return this[t];
                var r =new DictIdObj();
                Add(t, r);
                return r;
            }

            public DictIdObj GerIfHas(Type t)
            {
                TryGetValue(t, out var r);
                return r;
            }
        }
        
        public class DictIdObj : Dictionary<object, object>
        {
            public bool HasID(object id) => ContainsKey(id); 
            
            public T Get<T>(object id) => Get(id, typeof(T)) is T ? (T) Get(id, typeof(T)) : default;

            public object Get(object id, Type t)
            {
                if (HasID(id) == false)
                {
                    Debug.LogError($"No object under this id {id.ToString()}, by Type {t.Name}");
                    return default;
                }

                var r = this[id];
                return r;
            }

            public void Set(object target, object id)
            {
                if (HasID(id))
                {
                    Debug.LogError($"Объект под id {id.ToString()} уже существует");
                    return;
                }

                this[id] = target;
            }
        }
    }
}