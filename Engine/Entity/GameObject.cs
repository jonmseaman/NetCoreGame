using Engine.Level;

namespace Engine.Entity
{
    public abstract class GameObject
    {
        /// <summary>
        /// Update the GameObject by one tick.
        /// </summary>
        public abstract void Update(GameTime gameTime);

        public Location Location;
    }
}