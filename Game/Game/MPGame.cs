using System;
using System.Threading;
using Engine;
using Engine.Entity;
using Engine.Level;
using Game.UI;

namespace Game.Game
{
    public class MpGame : Engine.Game
    {
        private IGameState _state;

        public MpGame()
        {
            // Set up state.
            SetState(new GameMainMenuState(this));
        }

        public IGameState GetState()
        {
            return _state;
        }

        public void SetState(IGameState value)
        {
            _state?.Exit();
            _state = value;
            _state.Enter();
        }

        public Player Player { get; set; }
        public ILevel Level { get; set; }

        #region Menu Functions

        public void StartGame()
        {
            if (Player == null) SelectPlayer();
            if (Level == null) SelectLevel();
            Level.Add(new Location(), Player);
            SetState(new GamePlayingState(this));
        }

        public void SelectPlayer()
        {
            Player = new Player()
            {
                Name = "Jon"
            };
        }

        public void SelectLevel()
        {
            Level = new SquareLevel(256);
        }

        public void ExitGame()
        {
            Console.Clear();
            Console.WriteLine("Exiting...");
            Thread.Sleep(500);
            Environment.Exit(0);
        }

        #endregion

        #region Game

        public override void ProcessUserInput(GameTime gameTime)
        {
            GetState().ProcessUserInput(gameTime);
        }

        public override void Render(GameTime gameTime)
        {
            GetState().Render(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            GetState().Update(gameTime);
        }

        #endregion
    }
}