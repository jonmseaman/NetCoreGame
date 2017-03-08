using System;
using System.Collections.Generic;
using System.Threading;
using MPEngine;
using MPEngine.Commands;
using MPEngine.Controller;
using MPEngine.Entity;
using MPEngine.Entity.Commands;
using MPEngine.Level;
using MPGame.UI;

namespace MPGame
{
    class MpGame : Game
    {
        public IList<GameObject> GameObjects;
        private IList<IController> _controllers = new List<IController>();
        private MainView _view;

        public MpGame()
        {
            GameObjects = new List<GameObject>()
            {
                new Creature()
                {
                    Graphics = new SimpleCreatureGraphicsComponent()
                }
            };

            var kb = new ConsoleKeyboardController();
            kb.AddKeyPressedCommand(ConsoleKey.Escape, new RelayCommand(new Action(() =>
            {
                Console.WriteLine("Exiting...");
                Thread.Sleep(250);
                Environment.Exit(0);
            })));
            _controllers.Add(kb);

            // Add player.
            var player = new Creature()
            {
                Graphics = new SimpleCreatureGraphicsComponent()
            };
            _view = new MainView(player);
            kb.AddKeyPressedCommand(ConsoleKey.W, new MoveCommand(player, Direction.North));
            kb.AddKeyPressedCommand(ConsoleKey.A, new MoveCommand(player, Direction.West));
            kb.AddKeyPressedCommand(ConsoleKey.S, new MoveCommand(player, Direction.South));
            kb.AddKeyPressedCommand(ConsoleKey.D, new MoveCommand(player, Direction.East));
            kb.AddKeyPressedCommand(ConsoleKey.T, new TakeDamageCommand(player));
            GameObjects.Add(player);
        }

        public override void ProcessUserInput()
        {
            foreach (var controller in _controllers)
            {
                controller.ProcessUserInput();
            }
        }

        public override void Render(TimeSpan dt)
        {
            _view.Render();
        }

        public override void Update(TimeSpan dt)
        {
            foreach (var gameObject in GameObjects)
            {
                gameObject.Update(dt);
            }
            _view.Update();
        }
    }
}
