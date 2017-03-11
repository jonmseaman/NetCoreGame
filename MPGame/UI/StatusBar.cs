using System;
using MPEngine.Entity;

namespace MPGame.UI
{
    public class StatusBar : UIComponent
    {
        private Creature _creature;

        public StatusBar(Creature c)
        {
            _creature = c;
        }

        public override void Update()
        {
            // Do nothing.
        }

        public override void Render()
        {
            Console.CursorTop = Top;
            Console.CursorLeft = Left;

            // Print location.
            var x = _creature.Location.X;
            var y = _creature.Location.Y;
            var loc = $"({x},{y})".PadRight(Width - 1);
            if (loc.Length <= Width)
                Console.Write(loc);
        }
    }
}