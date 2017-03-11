using System;
using MPEngine;
using MPGame.Game;

namespace MPGame.UI.Menus
{
    public class MainMenuView : IComponent
    {
        public MpGame Game { get; set; }
        public MainMenuViewModel Model { get; set; }

        public MainMenuView(MpGame game)
        {
            Game = game;
            Model = new MainMenuViewModel(game);
        }

        public void Update()
        {
            Model.Menu.Update();
        }

        public void Render()
        {
            Model.Menu.Render();
        }
    }
}