using System;
using System.Threading;

namespace MPEngine
{
    public abstract class Game : IGameLoop
    {
        public bool Running { get; set; }

        public abstract void ProcessUserInput(GameTime gameTime);
        public abstract void Render(GameTime gameTime);
        public abstract void Update(GameTime gameTime);


        public void Run()
        {
            Running = true;

            var previous = DateTime.Now;
            var lag = TimeSpan.Zero;

            // Time per update.
            var dt = TimeSpan.FromMilliseconds(20);

            while (Running)
            {
                var gameTime = new GameTime(dt);
                var current = DateTime.Now;
                var elapsed = current - previous;
                previous = current;
                lag += elapsed;

                ProcessUserInput(gameTime);
                
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