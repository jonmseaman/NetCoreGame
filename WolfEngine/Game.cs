using System;
using System.Runtime.InteropServices;
using System.Threading;
using WolfEngine.Entity;

namespace WolfEngine
{
    public class Game : IGameLoop
    {
        public GameObject Focus { get; set; }
        public bool Running { get; set; }

        public void Loop()
        {
            Running = true;

            var previous = DateTime.Now;
            var current = DateTime.Now;
            var elapsed = TimeSpan.Zero;
            var lag = TimeSpan.Zero;

            // Time per update.
            var dt = TimeSpan.FromMilliseconds(20);

            while (Running)
            {
                current = DateTime.Now;
                elapsed = current - previous;
                previous = current;
                lag += elapsed;

                // TODO: Process Input.

                while (lag >= dt)
                {
                    Focus.Update();
                    lag -= dt;
                }

                // TODO: Render

                // Sleep until next time to update.
                elapsed = DateTime.Now - previous;

                var sleep = dt - elapsed;
                if (sleep > TimeSpan.Zero)
                {
                    //System.Threading.Thread.Sleep(sleep);
                    System.Threading.Thread.Sleep(sleep);
                }
            }
        }
    }
}