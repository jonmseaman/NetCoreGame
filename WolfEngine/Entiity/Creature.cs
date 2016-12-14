using System;
using WolfEngine.Level;

namespace WolfEngine.Entiity
{
    /// <summary>
    ///     Encapsulates basic behavior of creatures.
    /// </summary>
    public class Creature : IEntity
    {
        public CreatureAttributes Attributes { get; set; }

        public event CreatureMovedEventHandler Moved;

        public void Move(Direction dir)
        {
            if (Moved == null) return;

            var args = new CreatureMovedEventArgs(dir);
            Moved(this, args);
        }

        public void Update()
        {
            // TODO: Implement Update
            throw new NotImplementedException();
        }
    }

    public delegate void CreatureMovedEventHandler(object sender, CreatureMovedEventArgs e);

    public class CreatureMovedEventArgs : EventArgs
    {
        public CreatureMovedEventArgs(Direction dir)
        {
            Direction = dir;
        }

        public Direction Direction { get; set; }
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