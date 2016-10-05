using System;

namespace WolfEngine.Entiity
{
    /// <summary>
    ///     Encapsulates basic behavior of creatures.
    /// </summary>
    public class Creature
    {
        public CreatureAttributes Attributes { get; set; }

        public event ItemUsedEventHandler ItemUsed;

        // TODO: Add an inventory
        public Inventory Inventory { get; }
        // TODO: Add equipment for equipable items

    }

    public delegate void ItemUsedEventHandler(object sender, ItemUsedEventArgs e);

    public class ItemUsedEventArgs : EventArgs
    {
        public ItemUsedEventArgs(Item item, Creature usedOn)
        {
            UsedOn = usedOn;
            ItemUsed = item;
        }

        public Creature UsedOn { get; }
        public Item ItemUsed { get; }
    }
}