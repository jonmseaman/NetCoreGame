using System;
using System.Collections.Generic;
using Engine;
using Engine.Controller;
using Game.GameCommands;
using Game.UI;
using Game.UI.Menus;

namespace Game.Game
{
    public class GameMainMenuState : IGameState
    {
        private MainMenuView _mainMenu;
        private IController _controller;

        public GameMainMenuState(MpGame game)
        {
            _mainMenu = new MainMenuView(game);
            var kb = new ConsoleKeyboardController();
            var up = new MenuViewUpCommand(_mainMenu);
            var down = new MenuViewDownCommand(_mainMenu);
            kb.AddKeyPressedCommand(ConsoleKey.W, up);
            kb.AddKeyPressedCommand(ConsoleKey.UpArrow, up);
            kb.AddKeyPressedCommand(ConsoleKey.S, down);
            kb.AddKeyPressedCommand(ConsoleKey.DownArrow, down);
            kb.AddKeyPressedCommand(ConsoleKey.Enter, new MenuExecuteCommand(_mainMenu));
            kb.AddKeyPressedCommand(ConsoleKey.Escape, new MenuExitCommand(_mainMenu));
            _controller = kb;
        }

        #region IGameState
        public void ProcessUserInput(GameTime gameTime)
        {
            _controller.ProcessUserInput(gameTime);
        }

        public void Update(GameTime gameTime)
        {
            _mainMenu.Update();
        }

        public void Render(GameTime gameTime)
        {
            _mainMenu.Render();
        }

        public void Enter()
        {
            Console.Clear();
        }

        public void Exit()
        {
            // Do nothing.
        }

        #endregion
    }
}
