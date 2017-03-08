using System;
using System.Collections.Generic;
using System.Text;
using MPEngine.Commands;

namespace MPEngine.Entity.Commands
{
    public class TakeDamageCommand : Cmd<Creature>
    {
        public TakeDamageCommand(Creature receiver) : base(receiver)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.Attributes.Health -= 1;
        }
    }
}
