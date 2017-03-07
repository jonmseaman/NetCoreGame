using System;
using MPEngine.Level;

namespace MPEngine.Entity
{
    public abstract class GameObject
    {
        /// <summary>
        /// Update the GameObject by one tick.
        /// </summary>
        public abstract void Update(TimeSpan dt);

        public Location Location;
    }
}