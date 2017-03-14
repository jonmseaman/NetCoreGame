using System;
using System.ComponentModel;
using Engine.Files;
using Game.Game;

namespace Game.UI.Menus
{
    public class MainMenuView : IComponent
    {
        private bool _forceRedraw = true;

        public MainMenuView(MpGame game)
        {
            Game = game;
            Model = new MainMenuViewModel(game, this);
        }

        public MpGame Game { get; set; }
        public MainMenuViewModel Model { get; set; }

        public void HandlePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (sender == Model.PlayerSelectView && args.PropertyName.Equals(nameof(Model.PlayerSelectView.SelectedPlayer)))
            {
                var p = Model.PlayerSelectView.SelectedPlayer;
                Model.Player = p;
                Game.Player = p;
                UpdatePlayerSheet();
            }
        }

        private void UpdatePlayerSheet()
        {
            var sheet = new PlayerSheetView(Model.Player)
            {
                Left = 2 * Console.WindowWidth / 4,
                Width = Console.WindowWidth / 4
            };
            Model.PlayerSheet = sheet;
        }

        #region Menu Actions
        public void MenuExecute(object arg = null)
        {
            Model.MenuStack.Peek().Execute(arg);
        }

        public void MenuDown()
        {
            Model.MenuStack.Peek().ActiveItem++;
        }

        public void MenuUp()
        {
            Model.MenuStack.Peek().ActiveItem--;
        }

        public void EnterSubMenu(IComponent view, MenuView menu)
        {
            Model.MenuStack.Push(menu);
            Model.ViewStack.Push(view);
        }

        public void ExitSubMenu()
        {
            Model.MenuStack.Pop();
            Model.ViewStack.Pop();
            Console.Clear();
            if (Model.MenuStack.Count == 0) Game.ExitGame();
            Redraw();
        }
        public void EnterPlayerSelect()
        {
            var players = SaveData.LoadPlayers();
            Model.PlayerSelectView = new PlayerSelectView(players) { Left = 30 };
            var view = Model.PlayerSelectView;
            view.PropertyChanged += HandlePropertyChanged;
            EnterSubMenu(view, view.Menu);
        }
        #endregion

        #region IComponent

        public void Update()
        {
            Model.ViewStack.Peek().Update();
            Model.PlayerSheet?.Update();
        }

        public void Render()
        {
            Model.ViewStack.Peek().Render();
            Model.PlayerSheet?.Render();
        }

        public void Redraw()
        {
            Console.Clear();
            Model.ViewStack.Peek().Redraw();
            Model.PlayerSheet?.Redraw();
        }

        #endregion
    }
}