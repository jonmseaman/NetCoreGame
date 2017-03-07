using System;
using System.Collections.Generic;
using System.Threading;
using MPEngine;
using MPEngine.Commands;
using MPEngine.Controller;
using MPEngine.Entity;

namespace MPGame
{
    class MpGame : Game
    {
        public IList<GameObject> GameObjects;
        private IList<IController> _controllers = new List<IController>();
        private MainView View = new MainView();

        public MpGame()
        {
            GameObjects = new List<GameObject>()
            {
                new Creature()
                {
                    Graphics = new SimpleCreatureGraphicsComponent()
                }
            };

            View.Model.Player = GameObjects[0] as Creature;

            var kb = new ConsoleKeyboardController();
            kb.AddKeyPressedCommand(ConsoleKey.Escape, new RelayCommand(new Action(() =>
            {
                Console.WriteLine("Exiting...");
                Thread.Sleep(250);
                Environment.Exit(0);
            })));
            _controllers.Add(kb);
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
            View.Render(dt);
        }

        public override void Update(TimeSpan dt)
        {
            foreach (var gameObject in GameObjects)
            {
                gameObject.Update(dt);
            }
        }
    }
}
