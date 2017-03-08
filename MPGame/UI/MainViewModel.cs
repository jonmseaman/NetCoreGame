using System;
using MPEngine.Entity;

namespace MPGame.UI
{
    class MainViewModel
    {
        public MainViewModel(Creature player)
        {
            HealthBar = new HealthBar(player)
            {
                Width = Console.WindowWidth / 2
            };
            EnergyBar = new EnergyBar(player)
            {
                Width = Console.WindowWidth / 2,
                Left = Console.WindowWidth / 2
            };
            StatusBar = new StatusBar(player)
            {
                Width = Console.WindowWidth,
                Top = Console.WindowHeight - 1
            };

            Player = player;
        }

        public Creature Player { get; set; }

        public StatBar HealthBar { get; }

        public StatBar EnergyBar { get; }

        public StatusBar StatusBar { get; }
    }
}
