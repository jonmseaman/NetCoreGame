﻿using Engine.Commands;

namespace Game.UI.Menus
{
    public class MenuViewDownCommand : Cmd<MenuView>
    {
        public MenuViewDownCommand(MenuView receiver) : base(receiver)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.ActiveItem--;
        }
    }
}