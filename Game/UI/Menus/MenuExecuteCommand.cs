using Engine.Commands;

namespace Game.UI.Menus
{
    public class MenuExecuteCommand : Cmd<MainMenuView>
    {
        public MenuExecuteCommand(MainMenuView receiver) : base(receiver)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.MenuExecute(arg);
        }
    }
}