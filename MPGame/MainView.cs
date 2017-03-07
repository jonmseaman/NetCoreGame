using System;
using System.Collections.Generic;
using System.Text;
using MPEngine.Entity;

namespace MPGame
{
    class MainView
    {
        public MainView()
        {
            Model = new MainViewModel();
        }

        public MainViewModel Model { get; set; }


        public void Render(TimeSpan dt)
        {
            Console.CursorTop = 0;
            Console.CursorLeft = 0;

            // Draw health bar for player.
            if (Model.Player != null)
            {
                DrawHealthBar(Model.Player);
            }
        }

        private void DrawHealthBar(Creature modelPlayer)
        {
            var hp = modelPlayer.Attributes.Health;
            var maxHp = modelPlayer.Attributes.MaxHealth;

            var count = Console.WindowWidth * hp / maxHp;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < count; i++)
            {
                Console.Write(' ');
            }
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = count + 1; i < Console.WindowWidth; i++)
            {
                Console.Write(' ');
            }
        }
    }
}
