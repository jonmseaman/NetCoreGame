using System;
using Engine;
using Engine.Controller;
using Game.GameCommands;
using Game.UI.Menus;

namespace Game.Game
{
    public class MpGameMainMenuState : IMpGameState
    {
        private MainMenuView _mainMenu;
        private IController _controller;

        public MpGameMainMenuState(MpGame game)
        {
            _mainMenu = new MainMenuView(game);
            var kb = new ConsoleKeyboardController();
            var menu = _mainMenu.Model.Menu;
            kb.AddKeyPressedCommand(ConsoleKey.W, new MenuViewDownCommand(menu));
            kb.AddKeyPressedCommand(ConsoleKey.S, new MenuViewUpCommand(menu));
            kb.AddKeyPressedCommand(ConsoleKey.Enter, new MenuExecuteCommand(menu));
            kb.AddKeyPressedCommand(ConsoleKey.Escape, new ExitGameCommand(game));
            _controller = kb;
        }

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
    }
}