using MPEngine.Commands;

namespace MPGame.GameCommands
{
    public class StartGameCommand : Cmd<MpGame>
    {
        public StartGameCommand(MpGame receiver) : base(receiver)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.StartGame();
        }
    }
}