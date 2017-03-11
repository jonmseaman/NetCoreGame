using MPEngine.Commands;
using MPGame.Game;

namespace MPGame.GameCommands
{
    public class SelectPlayerCommand : Cmd<MpGame>
    {
        public SelectPlayerCommand(MpGame receiver) : base(receiver)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.SelectPlayer();
        }
    }
}