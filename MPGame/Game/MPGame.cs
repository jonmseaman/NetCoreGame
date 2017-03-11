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

        public MpGame()
        {
            // Set up the controllers.
            var kb = new ConsoleKeyboardController();
            var exitCommand = new ExitGameCommand(this);
            kb.AddKeyPressedCommand(ConsoleKey.Escape, exitCommand);
            _controllers.Add(kb);

            // Set up level
            Level = new SquareLevel(256);
            // Add player.
            Player = new Creature();
            Level.Add(Location.Zero, Player);
            ActiveView = new MainMenuView(this);
            kb.AddKeyPressedCommand(ConsoleKey.W, new MoveCommand(Player, Direction.North));
            kb.AddKeyPressedCommand(ConsoleKey.A, new MoveCommand(Player, Direction.West));
            kb.AddKeyPressedCommand(ConsoleKey.S, new MoveCommand(Player, Direction.South));
            kb.AddKeyPressedCommand(ConsoleKey.D, new MoveCommand(Player, Direction.East));
            kb.AddKeyPressedCommand(ConsoleKey.T, new TakeDamageCommand(Player));
            // Set up state.
            State = new MpGameMainMenuState(this);
        }

        public IMpGameState State { get; set; }

        public IComponent ActiveView { get; set; }
        public Creature Player { get; set; }
        public ILevel Level { get; set; }

        #region Menu Functions

        public void StartGame()
        {
            if (Player == null) SelectPlayer();
            if (Level == null) SelectLevel();
            Level.Add(new Location(), Player);
        }

        public void SelectPlayer()
        {
            Player = new Creature();
        }

        public void SelectLevel()
        {
            Level = new SquareLevel(50);
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
            State.ProcessUserInput(gameTime);
        }

        public override void Render(GameTime gameTime)
        {
            State.Render(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }

        #endregion
    }
}