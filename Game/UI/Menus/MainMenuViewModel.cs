using Game.Game;
using Game.GameCommands;

namespace Game.UI.Menus
{
    public class MainMenuViewModel
    {
        public MenuView Menu = new MenuView();

        public MainMenuViewModel(MpGame game)
        {
            Menu.ListItems.Add("Start");
            Menu.ListItems.Add("Player");
            Menu.ListItems.Add("Level");
            Menu.Commands.Add(new StartGameCommand(game));
            Menu.Commands.Add(new SelectPlayerCommand(game));
            Menu.Commands.Add(new SelectLevelCommand(game));
        }
    }
}