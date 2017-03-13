using System.Collections;
using System.Collections.Generic;
using Engine.Commands;
using Engine.Entity;
using Game.UI.Menus;

namespace Game.UI
{
    /// <summary>
    /// View that allows the user to select or create a player.
    /// </summary>
    public class PlayerSelectView : UiComponent
    {
        private MenuView _menu = new MenuView();

        public PlayerSelectView(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                _menu.Add(player.Name, new NullCommand());
            }
        }

        public override void Update()
        {
            _menu.Update();
        }

        public override void Render()
        {
            _menu.Render();
        }
    }
}