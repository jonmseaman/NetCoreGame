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
        private IComponent _view2;

        public MpGame()
        {
            GameObjects = new List<GameObject>()
            {
                new Creature()
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
            var player = new Creature();
            _view = new GameView(player);
            var view2 = new ListView();
            view2.Add("Hello1", new NullCommand());
            view2.Add("Hello2", new NullCommand());
            view2.Add("Hello3", new NullCommand());
            view2.Add("Hello4", new NullCommand());
            view2.Top = 1;
            _view2 = view2;
            kb.AddKeyPressedCommand(ConsoleKey.W, new MoveCommand(player, Direction.North));
            kb.AddKeyPressedCommand(ConsoleKey.A, new MoveCommand(player, Direction.West));
            kb.AddKeyPressedCommand(ConsoleKey.S, new MoveCommand(player, Direction.South));
            kb.AddKeyPressedCommand(ConsoleKey.D, new MoveCommand(player, Direction.East));
            kb.AddKeyPressedCommand(ConsoleKey.T, new TakeDamageCommand(player));

            var kb1 = new ConsoleKeyboardController();
            kb1.AddKeyPressedCommand(ConsoleKey.S, new ListViewUpCommand(view2));
            kb1.AddKeyPressedCommand(ConsoleKey.W, new ListViewDownCommand(view2));
            kb1.AddKeyPressedCommand(ConsoleKey.Enter, new ListViewExecuteCommand(view2));
            _controllers.Add(kb1);

            GameObjects.Add(player);
        }

        public override void ProcessUserInput(GameTime gameTime)
        {
            foreach (var controller in _controllers)
            {
                controller.ProcessUserInput(gameTime);
            }
        }

        public override void Render(GameTime gameTime)
        {
            _view.Render();
            _view2.Render();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var gameObject in GameObjects)
            {
                gameObject.Update(gameTime);
            }
            _view.Update();
            _view2.Update();
        }
    }
}
