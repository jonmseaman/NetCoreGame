using System;
using System.Runtime.InteropServices;
using System.Threading;
using MPEngine.Entity;

namespace MPEngine
{
    public abstract class Game : IGameLoop
    {
        public bool Running { get; set; }

        public abstract void ProcessUserInput();
        public abstract void Render(GameTime gameTime);
        public abstract void Update(GameTime gameTime);


        public void Run()
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

                ProcessUserInput();
                
                var gameTime = new GameTime(dt);
                while (lag >= dt)
                {
                    Update(gameTime);
                    lag -= dt;
                }

                Render(gameTime);

                // Sleep until next time to update.
                elapsed = DateTime.Now - previous;

                var sleep = dt - elapsed;
                if (sleep > TimeSpan.Zero)
                {
                    Thread.Sleep(sleep);
                }
            }
        }
    }
}