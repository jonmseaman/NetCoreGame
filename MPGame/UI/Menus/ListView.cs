﻿using System;
using System.Collections.Generic;
using MPEngine.Commands;

namespace MPGame.UI.Menus
{
    public class ListView : UiComponent
    {
        private int _activeItem;
        private bool _activeItemChanged = true;
        public List<string> ListItems { get; } = new List<string>();

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
                if (_activeItem >= ListItems.Count) _activeItem = ListItems.Count - 1;
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
            for (var i = 0; i < ListItems.Count; i++)
            {
                Console.CursorLeft = Left;
                Console.CursorTop = Top + i;
                if (i == ActiveItem) Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write($"{i + 1}: {ListItems[i]}");
                if (i == ActiveItem) Console.BackgroundColor = ConsoleColor.Black;
            }
            _activeItemChanged = false;
        }
    }
}