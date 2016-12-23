using System.Collections.Concurrent;
using System.Collections.Generic;
using WolfEngine.Level;

namespace WolfEngine.Entity
{
    public abstract class GameObject
    {
        public abstract void Update();

        public Location Location;
    }
}