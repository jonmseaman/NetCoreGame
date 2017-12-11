using System;

namespace Engine.Commands
{
    public class RelayCommand : Cmd<Action>
    {
        public RelayCommand(Action receiver) : base(receiver)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.Invoke();
        }
    }
}