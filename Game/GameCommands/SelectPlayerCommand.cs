using Engine.Commands;
using Game.Game;

namespace Game.GameCommands
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