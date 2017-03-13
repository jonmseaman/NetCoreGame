using System.Collections.Generic;
using Engine.Commands;
using Game.Game;
using Game.GameCommands;

namespace Game.UI.Menus
{
    public class MainMenuViewModel
    {
        public MenuView MainMenu = new MenuView();

        public Stack<MenuView> MenuStack = new Stack<MenuView>();

        public MainMenuViewModel(MpGame game)
        {
            MainMenu.Add("Start", new StartGameCommand(game));
            MainMenu.Add("Player", new NullCommand());
            MainMenu.Add("Level", new NullCommand());
            MenuStack.Push(MainMenu);
        }
    }
}