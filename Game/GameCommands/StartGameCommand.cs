using Engine.Commands;
using Game.Game;

namespace Game.GameCommands
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