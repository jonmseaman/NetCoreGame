using System;
using System.Collections.Generic;
using MPEngine.Commands;
using MPEngine.Controller;
using MPGame.UI;

namespace MPGame.Menus
{
    public class ListView : UIComponent
    {
        private int _activeItem;
        private List<Tuple<string, ICommand>> _listItems = new List<Tuple<string, ICommand>>();
        private bool _activeItemChanged = true;

        /// <summary>
        /// Gets or sets the index of the highlighted list item.
        /// </summary>
        public int ActiveItem
        {
            get { return _activeItem; }
            set
            {
                _activeItemChanged = true;
                _activeItem = value;
                if (_activeItem < 0) _activeItem = 0;
                if (_activeItem >= _listItems.Count) _activeItem = _listItems.Count - 1;
            }
        }

        public override void Update()
        {
            // Do nothing.
        }

        public override void Render()
        {
            if (!_activeItemChanged) return;
            // Draw entire list.
            for (var i = 0; i < _listItems.Count; i++)
            {
                Console.CursorLeft = Left;
                Console.CursorTop = Top + i;
                if (i == ActiveItem) Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write($"{i + 1}: {_listItems[i].Item1}");
                if (i == ActiveItem) Console.BackgroundColor = ConsoleColor.Black;
            }
            _activeItemChanged = false;
        }

        public void Execute()
        {
            _listItems[ActiveItem].Item2.Execute();
        }

        #region List Operations

        public void Add(string item, ICommand cmd)
        {
            _listItems.Add(new Tuple<string, ICommand>(item, cmd));
        }

        public bool Remove(Tuple<string, ICommand> item)
        {
            return _listItems.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _listItems.RemoveAt(index);
        }

        public void Clear()
        {
            _listItems.Clear();
        }

        #endregion
    }
}