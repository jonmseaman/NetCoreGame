﻿using System;
using System.Runtime.InteropServices;
using System.Threading;
using WolfEngine.Entity;

namespace WolfEngine
{
    public abstract class Game : IGameLoop
    {
        public bool Running { get; set; }

        public abstract void ProcessUserInput();
        public abstract void Render(TimeSpan dt);
        public abstract void Update(TimeSpan dt);


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

                while (lag >= dt)
                {
                    Update(dt);
                    lag -= dt;
                }

                Render(dt);

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