using System.Collections.Generic;
using MPEngine.Commands;
using MPGame.GameCommands;

namespace MPGame.UI.Menus
{
    public class MainMenuViewModel
    {
        public ListView Menu = new ListView();
        public List<ICommand> Commands = new List<ICommand>();

        public MainMenuViewModel(MpGame game)
        {
            Menu.ListItems.Add("Start");
            Menu.ListItems.Add("Player");
            Menu.ListItems.Add("Level");
            Commands.Add(new StartGameCommand(game));
            Commands.Add(new SelectPlayerCommand(game));
            Commands.Add(new SelectLevelCommand(game));
        }
    }
}