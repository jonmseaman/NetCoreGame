using System;
using Engine;
using Engine.Controller;
using Engine.Entity.Commands;
using Engine.Level;
using Game.GameCommands;
using Game.UI;

namespace Game.Game
{
    public class GamePlayingState : IGameState
    {
        private IComponent _view;
        private IController _controller;

        public GamePlayingState(MpGame game)
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

        public void Exit()
        {
            // Do nothing.
        }
    }
}