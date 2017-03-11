﻿using MPEngine.Commands;

namespace MPGame.Menus
{
    public class ListViewUpCommand : Cmd<ListView>
    {
        public ListViewUpCommand(ListView receiver) : base(receiver)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.ActiveItem++;
        }
    }
}