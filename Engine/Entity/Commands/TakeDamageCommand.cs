using Engine.Commands;

namespace Engine.Entity.Commands
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