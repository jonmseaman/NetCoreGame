using Engine.Commands;
using Engine.Entity;

namespace Game.UI
{
    public class PlayerSelectViewSelectCommand : Cmd<PlayerSelectView>
    {
        private Player _player;
        public PlayerSelectViewSelectCommand(PlayerSelectView playerSelectView, Player player) : base(playerSelectView)
        {
            _player = player;
        }

        public override void Execute(object arg = null)
        {
            Receiver.SelectedPlayer = _player;
        }
    }
}