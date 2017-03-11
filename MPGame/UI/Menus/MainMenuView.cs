using System;

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
            Model.MenuItems.Update();
        }

        public void Render()
        {
            Model.MenuItems.Render();
        }
    }
}