using System;
using MPEngine;
using MPEngine.Controller;
using MPEngine.Entity;
using MPEngine.Entity.Commands;
using MPEngine.Level;
using MPGame.GameCommands;
using MPGame.UI;
using MPGame.UI.Menus;

namespace MPGame.Game
{
    public class MpGamePlayingState : IMpGameState
    {
        private IComponent _view;
        private IController _controller;

        public MpGamePlayingState(MpGame game)
        {
            // Add player.
            var player = game.Player;
            _view = new GameView(player);

            // Set up controller.
            var kb = new ConsoleKeyboardController();
            var exitCommand = new ExitGameCommand(game);
            kb.AddKeyPressedCommand(ConsoleKey.Escape, exitCommand);
            kb.AddKeyPressedCommand(ConsoleKey.W, new MoveCommand(player, Direction.North));
            kb.AddKeyPressedCommand(ConsoleKey.A, new MoveCommand(player, Direction.West));
            kb.AddKeyPressedCommand(ConsoleKey.S, new MoveCommand(player, Direction.South));
            kb.AddKeyPressedCommand(ConsoleKey.D, new MoveCommand(player, Direction.East));
            kb.AddKeyPressedCommand(ConsoleKey.T, new TakeDamageCommand(player));
            _controller = kb;
        }

        public void ProcessUserInput(GameTime gameTime)
        {
            _controller.ProcessUserInput(gameTime);
        }

        public void Update(GameTime gameTime)
        {
            _view.Update();
        }

        public void Render(GameTime gameTime)
        {
            _view.Render();
        }

        public void Enter()
        {
            Console.Clear();
        }
    }
}