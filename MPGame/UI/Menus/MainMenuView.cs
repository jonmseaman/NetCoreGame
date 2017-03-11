using System;

namespace MPGame.UI.Menus
{
    public class MainMenuView : IComponent
    {
        public MainMenuViewModel Model { get; set; }

        public MainMenuView()
        {
            Model = new MainMenuViewModel();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Render()
        {
            throw new NotImplementedException();
        }
    }
}