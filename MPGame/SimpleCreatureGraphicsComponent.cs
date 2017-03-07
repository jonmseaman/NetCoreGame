using System;
using System.Collections.Generic;
using System.Text;
using MPEngine.Entity;

namespace MPGame
{
    class SimpleCreatureGraphicsComponent : ICreatureGraphicsComponent
    {
        public void Render(Creature c)
        {
            Console.CursorTop = 0;
            Console.WriteLine($"Creature location: {c.Location.X}, {c.Location.Y}.");
        }

        public void Update(Creature c)
        {
            // Do nothing.
        }
    }
}
