using System;
using MPEngine.Entity;

namespace MPGame.UI
{
    public class StatusBar : IComponent
    {
        private Creature _creature;

        public StatusBar(Creature c)
        {
            _creature = c;
        }

        /// <summary>
        ///     The position of the top of the status bar.
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        ///     The left-most position of the status bar.
        /// </summary>
        public int Left { get; set; }

        public int Width { get; set; }

        public void Update()
        {
            // Do nothing.
        }

        public void Render()
        {
            Console.CursorTop = Top;
            Console.CursorLeft = Left;

            // Print location.
            var x = _creature.Location.X;
            var y = _creature.Location.Y;
            var loc = $"({x},{y})".PadRight(Width - 1);
            if (loc.Length <= Width)
            {
                Console.Write(loc);
            }
        }
    }
}