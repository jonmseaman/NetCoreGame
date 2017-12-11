using Engine.Commands;

namespace Game.UI.Menus
{
    public class MenuViewUpCommand : Cmd<MainMenuView>
    {
        public MenuViewUpCommand(MainMenuView receiver) : base(receiver)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.MenuUp();
        }
    }
}