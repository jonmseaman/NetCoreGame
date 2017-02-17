namespace MPEngine.Entity
{
    public class Item
    {
        public Item()
        {
            Name = "";
        }

        public Item(string name)
        {
            Name = name;
        }

        // TODO: Method to handle usage of this item.

        public ItemAttributes Attributes { get; }
        public string Name { get; set; }
    }
}