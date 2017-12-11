using Engine.Commands;
using Game.Game;

namespace Game.GameCommands
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