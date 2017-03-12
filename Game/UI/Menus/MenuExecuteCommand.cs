using Engine.Commands;

namespace Game.UI.Menus
{
    public class MenuExecuteCommand : Cmd<MenuView>
    {
        public MenuExecuteCommand(MenuView receiver) : base(receiver)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.Execute(arg);
        }
    }
}