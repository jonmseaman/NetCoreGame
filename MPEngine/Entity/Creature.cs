using System;
using MPEngine.Level;

namespace MPEngine.Entity
{
    /// <summary>
    ///     Encapsulates basic behavior of creatures.
    /// </summary>
    public class Creature : GameObject
    {
        public Creature()
        {
            Attributes = new CreatureAttributes();
        }

        public CreatureAttributes Attributes { get; set; }

        protected IInputComponent Input;

        public ICreatureGraphicsComponent Graphics;

        public event CreatureMovedEventHandler OnMove;

        public void Move(Direction dir)
        {
            // Update location
            Location = Location.Add(Location, dir, 1);

            // OnMove event
            if (OnMove == null) return;

            var args = new CreatureMovedEventArgs(dir);
            OnMove(this, args);
        }

        public override void Update(TimeSpan dt)
        {
            Input?.Update(this);
            Graphics?.Update(this);
        }
    }

    #region Helpers

    public delegate void CreatureEventHandler(object sender, EventArgs e);

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

    #endregion
}