using System;
using System.Collections.Generic;
using System.Text;

namespace MPEngine.Commands
{
    public class NullCommand : ICommand
    {
        public NullCommand()
        {
        }

        public void Execute(object arg = null)
        {
        }
    }
}
