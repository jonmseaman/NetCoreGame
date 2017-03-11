using System;
using System.Collections.Generic;
using System.Threading;
using MPEngine;
using MPEngine.Commands;
using MPEngine.Controller;
using MPEngine.Entity;
using MPEngine.Entity.Commands;
using MPEngine.Level;
using MPGame.Menus;
using MPGame.UI;

namespace MPGame
{
    class MpGame : Game
    {
        public IList<GameObject> GameObjects;
        private IList<IController> _controllers = new List<IController>();
        private IComponent _view;

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
            var exitCommand = new RelayCommand(new Action(() =>
            {
                Console.Clear();
                Console.WriteLine("Exiting...");
                Thread.Sleep(500);
                Environment.Exit(0);
            }));
            kb.AddKeyPressedCommand(ConsoleKey.Escape, exitCommand);
            _controllers.Add(kb);

            // Add player.
            var player = new Creature()
            {
                Graphics = new SimpleCreatureGraphicsComponent()
            };
            //_view = new GameView(player);
            var view = new ListView();
            view.Add("Hello1", new NullCommand());
            view.Add("Hello2", new NullCommand());
            view.Add("Hello3", new NullCommand());
            view.Add("Hello4", new NullCommand());
            _view = view;
            //kb.AddKeyPressedCommand(ConsoleKey.W, new MoveCommand(player, Direction.North));
            //kb.AddKeyPressedCommand(ConsoleKey.A, new MoveCommand(player, Direction.West));
            //kb.AddKeyPressedCommand(ConsoleKey.S, new MoveCommand(player, Direction.South));
            //kb.AddKeyPressedCommand(ConsoleKey.D, new MoveCommand(player, Direction.East));
            //kb.AddKeyPressedCommand(ConsoleKey.T, new TakeDamageCommand(player));
            kb.AddKeyPressedCommand(ConsoleKey.S, new ListViewUpCommand(view));
            kb.AddKeyPressedCommand(ConsoleKey.W, new ListViewDownCommand(view));
            kb.AddKeyPressedCommand(ConsoleKey.Enter, new ListViewExecuteCommand(view));

            GameObjects.Add(player);
        }

        public override void ProcessUserInput()
        {
            foreach (var controller in _controllers)
            {
                controller.ProcessUserInput();
            }
        }

        public override void Render(GameTime gameTime)
        {
            _view.Render();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var gameObject in GameObjects)
            {
                gameObject.Update(gameTime);
            }
            _view.Update();
        }
    }
}
