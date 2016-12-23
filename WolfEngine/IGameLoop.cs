using WolfEngine.Entity;

namespace WolfEngine
{
    /// <summary>
    /// Interface for game loop design pattern. Used to manage game loop.
    /// </summary>
    public interface IGameLoop
    {
        /// <summary>
        /// The level being updated
        /// </summary>
        GameObject Focus { get; set; }

        /// <summary>
        /// The game loop should run while this is set to true.
        /// </summary>
        bool Running { get; set; }

        /// <summary>
        /// Run the loop while Running == True.
        /// </summary>
        void Loop();
    }
}