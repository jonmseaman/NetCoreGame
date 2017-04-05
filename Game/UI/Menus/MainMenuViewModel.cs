using System.Collections.Generic;
using Engine.Commands;
using Engine.Entity;
using Game.Game;
using Game.GameCommands;

namespace Game.UI.Menus
{
    public class MainMenuViewModel
    {
        public MenuView MainMenu = new MenuView();
        // TODO: Add level information view.


        public Stack<MenuView> MenuStack = new Stack<MenuView>();
        public Player Player;
        public Stack<IComponent> ViewStack = new Stack<IComponent>();


        public MainMenuViewModel(MpGame game, MainMenuView mainMenuView)
        {
            MainMenu.Add("Start", new StartGameCommand(game));
            MainMenu.Add("Player", new MainMenuEnterPlayerSelectCommand(mainMenuView));
            MainMenu.Add("Level", new NullCommand());
            MainMenu.Add("Exit", new ExitGameCommand(game));
            MenuStack.Push(MainMenu);
            ViewStack.Push(MainMenu);
        }

        public PlayerSelectView PlayerSelectView { get; set; }
        public PlayerSheetView PlayerSheet { get; set; }
    }
}