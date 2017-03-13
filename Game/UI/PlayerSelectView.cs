using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Engine.Commands;
using Engine.Entity;
using Game.Annotations;
using Game.UI.Menus;

namespace Game.UI
{
    /// <summary>
    /// View that allows the user to select or create a player.
    /// </summary>
    public class PlayerSelectView : UiComponent, INotifyPropertyChanged
    {
        private Player _selectedPlayer;
        public MenuView Menu = new MenuView();

        public PlayerSelectView(IEnumerable<Player> players)
        {
            Menu.Add("New".PadLeft(20), new NullCommand());
            foreach (var player in players)
                Menu.Add(player.Name, new PlayerSelectViewSelectCommand(this, player));
        }

        public Player SelectedPlayer
        {
            get { return _selectedPlayer; }
            set
            {
                _selectedPlayer = value;
                OnPropertyChanged();
            }
        }

        public override void Update()
        {
            Menu.Left = Left;
            Menu.Top = Top;
            Menu.Update();
        }

        public override void Render()
        {
            Menu.Render();
        }

        public override void Redraw()
        {
            Menu.Redraw();
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}