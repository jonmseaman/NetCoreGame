using System;
using System.Collections.Generic;
using System.Threading;
using MPEngine;
using MPEngine.Commands;
using MPEngine.Controller;
using MPEngine.Entity;
using MPEngine.Entity.Commands;
using MPEngine.Level;
using MPGame.GameCommands;
using MPGame.UI;
using MPGame.UI.Menus;

namespace MPGame.Game
{
    public class MpGame : MPEngine.Game
    {
        private IList<IController> _controllers = new List<IController>();
        private IMpGameState _state;

        public MpGame()
        {
            // Set up state.
            SetState(new MpGameMainMenuState(this));
        }

        public IMpGameState GetState()
        {
            return _state;
        }

        public void SetState(IMpGameState value)
        {
            _state = value;
            _state.Enter();
        }

        public IComponent ActiveView { get; set; }
        public Creature Player { get; set; }
        public ILevel Level { get; set; }

        #region Menu Functions

        public void StartGame()
        {
            if (Player == null) SelectPlayer();
            if (Level == null) SelectLevel();
            Level.Add(new Location(), Player);
            SetState(new MpGamePlayingState(this));
        }

        public void SelectPlayer()
        {
            Player = new Creature();
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