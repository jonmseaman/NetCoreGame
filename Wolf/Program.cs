using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf
{
    class Program
    {
        static void Main(string[] args)
        {
            var window = new TerminalWindow();
            window.SetCh('F', 20, 1);
            window.Render();
            Console.WriteLine("Hello, world!");
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
