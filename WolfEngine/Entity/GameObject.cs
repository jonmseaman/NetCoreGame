using System.Collections.Concurrent;
using System.Collections.Generic;
using WolfEngine.Level;

namespace WolfEngine.Entity
{
    public abstract class GameObject
    {
        /// <summary>
        /// Update the GameObject by one tick.
        /// </summary>
        public abstract void Update();

        public Location Location;
    }
}