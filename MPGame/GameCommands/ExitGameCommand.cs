using MPEngine.Commands;
using MPGame.Game;

namespace MPGame.GameCommands
{
    public class ExitGameCommand : Cmd<MpGame>
    {
        public ExitGameCommand(MpGame receiver) : base(receiver)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.ExitGame();
        }
    }
}