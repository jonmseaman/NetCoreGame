using MPEngine.Commands;
using MPEngine.Level;

namespace MPEngine.Entity.Commands
{
    public class MoveCommand : Cmd<Creature>
    {
        private Direction _dir;

        public MoveCommand(Creature receiver, Direction dir) : base(receiver)
        {
            _dir = dir;
        }

        public override void Execute(object arg = null)
        {
            Receiver.Move(_dir);
        }
    }
}
