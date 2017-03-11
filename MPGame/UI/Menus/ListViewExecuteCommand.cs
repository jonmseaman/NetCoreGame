using MPEngine.Commands;

namespace MPGame.UI.Menus
{
    public class ListViewExecuteCommand : Cmd<ListView>
    {
        public ListViewExecuteCommand(ListView receiver) : base(receiver)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.Execute();
        }
    }
}