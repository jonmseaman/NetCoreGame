using Engine.Commands;

namespace Game.UI.Menus
{
    public class MenuViewDownCommand : Cmd<MainMenuView>
    {
        public MenuViewDownCommand(MainMenuView receiver) : base(receiver)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.MenuDown();
        }
    }
}