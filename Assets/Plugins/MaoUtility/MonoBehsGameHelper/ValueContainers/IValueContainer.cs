namespace Plugins.MaoUtility.MonoBehsGameHelper.ValueContainers
{
    public interface IValueContainer<T>
    {
        public T Max { get; }
        public T Min { get; }
        public T Current { get; set; }
        public void Valid();
    }
}