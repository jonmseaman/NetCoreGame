using MPEngine.Commands;

namespace MPGame.UI.Menus
{
    public class MenuViewUpCommand : Cmd<MenuView>
    {
        public MenuViewUpCommand(MenuView receiver) : base(receiver)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.ActiveItem++;
        }
    }
}