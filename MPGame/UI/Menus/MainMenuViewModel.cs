using System.Collections.Generic;
using MPEngine.Commands;

namespace MPGame.UI.Menus
{
    public class MainMenuViewModel
    {
        public ListView MenuItems = new ListView();
        public List<ICommand> MenuItemCommands = new List<ICommand>();

        public MainMenuViewModel()
        {
            MenuItems.ListItems.Add("Start");
            MenuItems.ListItems.Add("Player");
            MenuItems.ListItems.Add("Level");
        }
    }
}