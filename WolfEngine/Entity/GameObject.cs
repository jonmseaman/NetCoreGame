using System;
using WolfEngine.Level;

namespace WolfEngine.Entity
{
    public abstract class GameObject
    {
        /// <summary>
        /// Update the GameObject by one tick.
        /// </summary>
        public abstract void Update(TimeSpan dt);

        /// <summary>
        /// Renders the GameObject on screen.
        /// </summary>
        public abstract void Render();

        public Location Location;
    }
}