using System;

namespace Engine
{
    public class GameTime
    {
        public GameTime(TimeSpan elapsed)
        {
            Elapsed = elapsed;
            Time = DateTime.Now;
        }

        /// <summary>
        /// Gets the time this object was created.
        /// </summary>
        public DateTime Time { get; }
        /// <summary>
        /// Gets the time elapsed since the last update.
        /// </summary>
        public TimeSpan Elapsed { get; }
    }
}