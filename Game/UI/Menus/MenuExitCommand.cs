using Engine.Commands;

namespace Game.UI.Menus
{
    public class MenuExitCommand : Cmd<MainMenuView>
    {
        public MenuExitCommand(MainMenuView mainMenu) : base(mainMenu)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.ExitSubMenu();
        }
    }
}