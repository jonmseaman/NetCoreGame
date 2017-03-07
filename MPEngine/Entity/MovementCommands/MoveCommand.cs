using System;
using System.Collections.Generic;
using System.Text;
using MPEngine.Commands;
using MPEngine.Level;

namespace MPEngine.Entity.MovementCommands
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
