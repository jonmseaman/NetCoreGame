namespace WolfEngine.Entity
{
    /// <summary>
    /// Provides an interface for a container that holds <see cref="Item"/>.
    /// </summary>
    public interface IInventory
    {
        Item this[int itemIndex] { get; set; }
        int Capacity { get; }
        bool Empty { get; }
        bool Full { get; }
        int Size { get; }

        bool Add(Item item);
        bool AddAt(Item item, int index);
        void Clear();
        bool Remove(Item item);
        bool RemoveAt(int index);
    }
}