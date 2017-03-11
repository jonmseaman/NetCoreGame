﻿using MPEngine.Commands;
using MPGame.Game;

namespace MPGame.GameCommands
{
    public class SelectLevelCommand : Cmd<MpGame>
    {
        public SelectLevelCommand(MpGame receiver) : base(receiver)
        {
        }

        public override void Execute(object arg = null)
        {
            Receiver.SelectLevel();
        }
    }
}