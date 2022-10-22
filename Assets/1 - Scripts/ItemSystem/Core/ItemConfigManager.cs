using Plugins.MaoUtility.DataManagers;

namespace DefaultNamespace.ItemSystem
{
    [System.Serializable]
    public class ItemConfigManager : DataManagerSystemObject<ItemConfig>
    {
        public T GetOrCreate<T>() where T : ItemConfig, new()
        {
            var r = Get<T>();
            if (r != null) return r;
            r = new T();
            Add(r);
            return r;
        }
    }
}