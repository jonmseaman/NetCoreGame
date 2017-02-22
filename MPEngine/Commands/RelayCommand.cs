using System;
using System.Collections.Generic;
using System.Text;

namespace MPEngine.Commands
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
