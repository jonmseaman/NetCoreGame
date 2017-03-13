using Game.Game;

namespace Game.UI.Menus
{
    public class MainMenuView : IComponent
    {
        public MainMenuView(MpGame game)
        {
            Game = game;
            Model = new MainMenuViewModel(game);
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

        #region IComponent

        public void Update()
        {
            Model.MenuStack.Peek().Update();
        }

        public void Render()
        {
            Model.MenuStack.Peek().Render();
        }

        #endregion
    }
}