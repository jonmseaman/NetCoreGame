using System.Collections.Concurrent;
using System.Collections.Generic;
using WolfEngine.Level;

namespace WolfEngine.Entity
{
    public abstract class Entity
    {
        public abstract void Update();

        public Location Location;
    }
}