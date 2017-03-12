using System;
using MPEngine.Entity;

namespace MPGame.UI
{
    public class PlayerSheetView : UiComponent
    {
        private Player _player;

        public PlayerSheetView(Player player)
        {
            Player = player;
        }

        public bool UpdateView { get; set; } = true;

        public Player Player
        {
            get { return _player; }
            set
            {
                _player = value;
                UpdateView = true;
            }
        }

        public override void Update()
        {
            // Do nothing.
        }

        public override void Render()
        {
            if (!UpdateView) return;
            var attrs = Player.Attributes;
            Left += 1;
            // Update view.
            Console.CursorTop = Top;
            Console.CursorLeft = Left;
            Console.WriteLine($"{Player.Name}");
            Console.CursorLeft = Left;
            Console.WriteLine($"Health: ({attrs.Health}/{attrs.MaxHealth})");
            Console.CursorLeft = Left;
            Console.WriteLine($"Energy: ({attrs.Energy},{attrs.MaxEnergy})");
            Console.CursorLeft = Left;
            Console.CursorTop += 1;

            // Attributes
            Console.WriteLine("Attributes: ");
            int attrpad = 17;
            Console.CursorLeft = Left;
            Console.WriteLine("\tStamina".PadRight(attrpad) + attrs.Stamina);
            Console.CursorLeft = Left;
            Console.WriteLine("\tStrength".PadRight(attrpad) + attrs.Strength);
            Console.CursorLeft = Left;
            Console.WriteLine("\tIntellect".PadRight(attrpad) + attrs.Intellect);
            Console.CursorLeft = Left;
            Console.WriteLine("\tAgility".PadRight(attrpad) + attrs.Agility);
            Console.CursorLeft = Left;
            Console.WriteLine("\tSpirit".PadRight(attrpad) + attrs.Spirit);

            // Experience.
            Console.CursorLeft = Left;
            Console.CursorTop += 1;
            Console.WriteLine($"Level: \t\t{attrs.Level}");
            Console.CursorLeft = Left;
            Console.WriteLine($"Experience: \t{attrs.Experience}");

            UpdateView = false;
            Left -= 1;
        }
    }
}