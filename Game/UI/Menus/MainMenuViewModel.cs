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
        public Stack<IComponent> ViewStack = new Stack<IComponent>();


        public MainMenuViewModel(MpGame game, MainMenuView mainMenuView)
        {
            MainMenu.Add("Start", new StartGameCommand(game));
            MainMenu.Add("Player",new MainMenuEnterPlayerSelectCommand(mainMenuView));
            MainMenu.Add("Level", new NullCommand());
            MainMenu.Add("Exit", new ExitGameCommand(game));
            MenuStack.Push(MainMenu);
            ViewStack.Push(MainMenu);
        }

    }

    public class MainMenuEnterPlayerSelectCommand : Cmd<MainMenuView>
    {
        public MainMenuEnterPlayerSelectCommand(MainMenuView mainMenuView) : base(mainMenuView)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.EnterPlayerSelect();
        }
    }
}