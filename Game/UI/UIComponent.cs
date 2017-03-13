namespace Game.UI
{
    public abstract class UiComponent : IComponent
    {
        public bool NeedsUpdate { get; set; } = true;

        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }

        public abstract void Update();

        public virtual void Render()
        {
            if (NeedsUpdate) Redraw();
            NeedsUpdate = false;
        }
        public abstract void Redraw();
    }
}