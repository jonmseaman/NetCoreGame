namespace Game.UI
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

        /// <summary>
        /// Redraws the entire component.
        /// </summary>
        void Redraw();
    }
}