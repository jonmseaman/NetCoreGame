using System;
using System.Collections.Generic;
using Engine.Commands;

namespace Game.UI.Menus
{
    public class MenuView : UiComponent
    {
        private int _activeItem;
        public List<string> ListItems { get; } = new List<string>();

        public List<ICommand> Commands { get; } = new List<ICommand>();

        /// <summary>
        /// Gets or sets the index of the highlighted list item.
        /// </summary>
        public int ActiveItem
        {
            get { return _activeItem; }
            set
            {
                NeedsUpdate = true;
                _activeItem = value;
                if (_activeItem < 0) _activeItem = 0;
                if (_activeItem >= ListItems.Count) _activeItem = ListItems.Count - 1;
            }
        }

        public void Execute(object arg = null)
        {
            Commands[ActiveItem].Execute(arg);
        }

        public override void Update()
        {
            // Do nothing.
        }

        public override void Redraw()
        {
            // Draw entire list.
            for (var i = 0; i < ListItems.Count; i++)
            {
                Console.CursorLeft = Left;
                Console.CursorTop = Top + i;
                if (i == ActiveItem) Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write($"{i + 1}: {ListItems[i]}");
                if (i == ActiveItem) Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public void Add(string itemText, ICommand cmd)
        {
            ListItems.Add(itemText);
            Commands.Add(cmd);
        }
    }
}