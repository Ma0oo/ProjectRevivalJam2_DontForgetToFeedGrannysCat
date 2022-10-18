namespace DefaultNamespace.ItemSystem.Inventory
{
    public interface IInventory
    {
        bool Add(Item item);
        bool Remove(Item item);
    }
}