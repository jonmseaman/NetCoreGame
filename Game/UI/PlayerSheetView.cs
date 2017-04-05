using System;
using System.Collections.Generic;
using Engine.Entity;

namespace Game.UI
{
    public class PlayerSheetView : UiComponent
    {
        private List<string> _lines;
        private Player _player;

        public PlayerSheetView(Player player)
        {
            Player = player;
            Width = Console.WindowWidth / 4;
        }

        public Player Player
        {
            get { return _player; }
            set
            {
                _player = value;
                NeedsUpdate = true;
            }
        }

        private void UpdateLines()
        {
            var attrs = Player.Attributes;
            const int attrpad = 17;
            var pad = Width - 2;
            _lines = new List<string>
            {
                $"{Player.Name}",
                $"Health: ({attrs.Health}/{attrs.MaxHealth})",
                $"Energy: ({attrs.Energy}/{attrs.MaxEnergy})",
                "",
                "Attributes: ",
                "\tStamina".PadRight(attrpad) + attrs.Stamina,
                "\tStrength".PadRight(attrpad) + attrs.Strength,
                "\tIntellect".PadRight(attrpad) + attrs.Intellect,
                "\tAgility".PadRight(attrpad) + attrs.Agility,
                "\tSpirit".PadRight(attrpad) + attrs.Spirit,
                "",
                $"Level: \t\t{attrs.Level}",
                $"Experience: \t{attrs.Experience}"
            };
            // Pad lines.
            for (var i = 0; i < _lines.Count; i++)
                _lines[i] = _lines[i].PadRight(pad);
        }

        public override void Update()
        {
            if (NeedsUpdate) UpdateLines();
        }

        public override void Redraw()
        {
            Left += 1;

            Console.CursorTop = Top;
            Console.CursorLeft = Left;
            foreach (var line in _lines)
            {
                Console.CursorLeft = Left;
                Console.WriteLine(line);
            }
            Left -= 1;
        }
    }
}