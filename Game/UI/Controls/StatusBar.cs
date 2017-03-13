using System;
using Engine.Entity;
using Engine.Level;

namespace Game.UI.Controls
{
    public class StatusBar : UiComponent
    {
        private Creature _creature;
        private Location _location;

        public StatusBar(Creature c)
        {
            _creature = c;
        }

        public Location Location
        {
            get { return _location; }
            set
            {
                if (_location.Equals(value)) return;
                _location = value;
                NeedsUpdate = true;
            }
        }

        public override void Update()
        {
            Location = _creature.Location;
        }

        public override void Redraw()
        {
            Console.CursorTop = Top;
            Console.CursorLeft = Left;

            // Print location.
            var x = Location.X;
            var y = Location.Y;
            var loc = $"({x},{y})".PadRight(Width - 1);
            if (loc.Length <= Width)
                Console.Write(loc);
        }
    }
}