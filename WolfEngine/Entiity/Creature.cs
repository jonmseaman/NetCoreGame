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

        protected IInputComponent Input;

        /// <summary>
        /// Send events to be handled.
        /// </summary>
        public event CreatureEventHandler HandleEvent;

        public void Move(Direction dir)
        {
            if (HandleEvent == null) return;

            var args = new CreatureMovedEventArgs(dir);
            HandleEvent(this, args);
        }

        public void Update()
        {
            Input?.Update(this);
        }
    }

    #region Helpers

    public delegate void CreatureEventHandler(object sender, EventArgs e);

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