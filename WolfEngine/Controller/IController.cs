
namespace WolfEngine.Controller
{
    /// <summary>
    /// Handles input from an input device.
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Gets input from controller, executes actions associated with the input.
        /// </summary>
        void ProcessUserInput();
    }
}
