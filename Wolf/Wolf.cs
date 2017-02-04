using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf
{
    class Wolf
    {
        static void Main(string[] args)
        {
            var window = new TerminalWindow();
            window.SetCh('F', 20, 1);
            window.Render();
            var game = new WolfGame();
            game.Loop();
        }
    }
}
