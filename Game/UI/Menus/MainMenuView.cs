using System;
using Engine.Files;
using Game.Game;

namespace Game.UI.Menus
{
    public class MainMenuView : IComponent
    {
        public MainMenuView(MpGame game)
        {
            Game = game;
            Model = new MainMenuViewModel(game, this);
        }

        public MpGame Game { get; set; }
        public MainMenuViewModel Model { get; set; }

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
        }

        #region IComponent

        public void Update()
        {
            Model.ViewStack.Peek().Update();
        }

        public void Render()
        {
            Model.ViewStack.Peek().Render();
        }

        public void Redraw()
        {
            Model.ViewStack.Peek().Redraw();
        }

        #endregion

        public void EnterPlayerSelect()
        {
            var players = SaveData.LoadPlayers();
            var view = new PlayerSelectView(players);
            view.Left = 30;
            EnterSubMenu(view, view.Menu);
        }
    }
}