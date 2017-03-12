namespace Engine.Level
{
    public interface ILevelGraphicsComponent
    {
        void Render(ILevel level);
        void Update(ILevel level);
    }
}