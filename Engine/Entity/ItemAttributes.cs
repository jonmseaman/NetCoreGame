using System;

namespace Engine.Entity
{
    public class ItemAttributes : Attributes
    {
        /// <summary>
        /// The damage per attack.
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        /// The time between attacks.
        /// </summary>
        public TimeSpan AttackTime { get; set; }
    }
}