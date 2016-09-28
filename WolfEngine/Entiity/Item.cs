using System;
using System.ComponentModel;

namespace WolfEngine.Entiity
{
    public class Item
    {
        public ItemAttributes Attributes { get; }
        public string Name { get; set; }

        // OnUse event / delegate
        public event ItemUsedEventHandler Used;

        protected virtual void OnUsed(ItemUsedEventArgs e)
        {
            Used?.Invoke(this, e);
        }
    }

    public delegate void ItemUsedEventHandler(object sender, ItemUsedEventArgs e);

    public class ItemUsedEventArgs : EventArgs
    {
        public ItemUsedEventArgs(Creature usedBy, Creature usedOn)
        {
            UsedOn = usedOn;
            UsedBy = usedBy;
        }

        public Creature UsedOn { get; }
        public Creature UsedBy { get; }
    }

}