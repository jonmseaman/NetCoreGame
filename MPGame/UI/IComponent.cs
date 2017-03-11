using MPEngine;

namespace MPGame.UI
{
    public interface IComponent
    {
        /// <summary>
        /// Updates the UI component.
        /// </summary>
        void Update();
        /// <summary>
        /// Renders the UI Component on screen.
        /// </summary>
        void Render();
    }
}