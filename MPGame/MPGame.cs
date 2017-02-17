using System;
using System.Collections.Generic;
using MPEngine;

namespace MPGame
{
    class MpGame : Game
    {
        public override void ProcessUserInput()
        {
            var list = new List<ConsoleKeyInfo>(5);
            while (Console.KeyAvailable) list.Add(Console.ReadKey(true));
        }

        public override void Render(TimeSpan dt)
        {
            throw new NotImplementedException();
        }

        public override void Update(TimeSpan dt)
        {
            throw new NotImplementedException();
        }
    }
}
