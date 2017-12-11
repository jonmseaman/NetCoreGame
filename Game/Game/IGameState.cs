using Engine;

namespace Game.Game
{
    public interface IGameState
    {
        void Enter();
        void Exit();
        void ProcessUserInput(GameTime gameTime);
        void Update(GameTime gameTime);
        void Render(GameTime gameTime);
    }
}