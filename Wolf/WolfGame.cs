using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfEngine;

namespace Wolf
{
    class WolfGame : Game
    {
        WolfEngine.Controller.IController _controller = new GameController();

        public WolfGame()
        {
            // TODO: Init Focus.
        }

        public override void ProcessUserInput()
        {
            _controller.ProcessUserInput();
        }


        public override void Render(TimeSpan dt)
        {
            // TODO: Render.
            Console.WriteLine("Render");
        }

        public override void Update(TimeSpan dt)
        {

        }
    }
}
