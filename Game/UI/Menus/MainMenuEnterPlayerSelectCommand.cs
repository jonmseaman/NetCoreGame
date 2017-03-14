using Engine.Commands;

namespace Game.UI.Menus
{
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