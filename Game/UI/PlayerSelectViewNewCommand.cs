using Engine.Commands;

namespace Game.UI
{
    public class PlayerSelectViewNewCommand : Cmd<PlayerSelectView>
    {
        public PlayerSelectViewNewCommand(PlayerSelectView playerSelectView) : base(playerSelectView)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.NewPlayer();
        }
    }
}