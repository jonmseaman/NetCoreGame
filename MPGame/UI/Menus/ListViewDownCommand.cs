using MPEngine.Commands;

namespace MPGame.Menus
{
    public class ListViewDownCommand : Cmd<ListView>
    {
        public ListViewDownCommand(ListView receiver) : base(receiver)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.ActiveItem--;
        }
    }
}