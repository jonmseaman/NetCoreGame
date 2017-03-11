using MPEngine;

namespace MPGame.Game
{
    public interface IMpGameState
    {
        void ProcessUserInput(GameTime gameTime);
        void Update(GameTime gameTime);
        void Render(GameTime gameTime);
    }
}