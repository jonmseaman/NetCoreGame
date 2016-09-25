using System;
using System.Collections.Generic;

namespace WolfEngine.Entiity
{
    /// <summary>
    /// An inventory with a fixed capacity.
    /// </summary>
    public class Inventory : IInventory
    {
        /// <summary>
        /// Underlying container for <see cref="Inventory"/>
        /// </summary>
        private readonly Item[] _inventory;

        /// <summary>
        /// Number of items currently stored in this.
        /// </summary>
        private int _count = 0;

        /// <summary>
        /// Creates an inventory with a specific maximum capacity.
        /// </summary>
        /// <param name="capacity">The maximum capacity of the inventory.</param>
        public Inventory(int capacity)
        {
            _inventory = new Item[capacity];
            for (int i = 0; i < _inventory.Length; i++)
            {
                _inventory[i] = null;
            }
        }

        #region IInventory

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemIndex"></param>
        /// <returns></returns>
        public Item this[int itemIndex]
        {
            get { return _inventory[itemIndex]; }
            set { _inventory[itemIndex] = value; }
        }

        public int Capacity => _inventory.Length;
        public bool Empty => _count == 0;
        public bool Full => _count == Capacity;
        public int Size => _count;

        public bool Add(Item item)
        {
            var added = false;
            for (int i = 0; i < _inventory.Length; ++i)
            {
                if (_inventory[i] == null)
                {
                    _inventory[i] = item;
                    _count++;
                    added = true;
                    break;
                }
            }
            return added;
        }

        public bool AddAt(Item item, int index)
        {
            bool added = false;
            if (_inventory[index] == null)
            {
                _inventory[index] = item;
                _count++;
                added = true;
            }

            return added;
        }

        public void Clear()
        {
            for (int i = 0; i < _inventory.Length; i++)
            {
                _inventory[i] = null;
            }
            _count = 0;
        }

        public bool Remove(Item item)
        {
            bool removed = false;
            for (int i = 0; i < _inventory.Length; i++)
            {
                var invItem = _inventory[i];
                if (invItem != null && invItem.Equals(item))
                {
                    _inventory[i] = null;
                    removed = true;
                    _count--;
                    break;
                }
            }
            return removed;
        }

        public bool RemoveAt(int index)
        {
            var removed = false;
            if (_inventory[index] != null)
            {
                _inventory[index] = null;
                _count--;
                removed = true;
            }
            return removed;
        }
        #endregion
    }
}