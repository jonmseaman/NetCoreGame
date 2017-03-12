namespace Game.UI
{
    public abstract class UiComponent : IComponent
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }

        public abstract void Update();
        public abstract void Render();
    }
}