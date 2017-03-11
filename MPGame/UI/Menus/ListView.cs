using System;
using System.Collections.Generic;
using MPEngine.Commands;
using MPGame.UI;

namespace MPGame.Menus
{
    public class ListView : IComponent
    {
        private List<Tuple<string, ICommand>> _listItems = new List<Tuple<string, ICommand>>();

        #region List Operations
        public void Add(string item, ICommand cmd)
        {
            _listItems.Add(new Tuple<string, ICommand>(item, cmd));
        }

        public void Remove(int index)
        {
            
        }

        #endregion

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Render()
        {
            throw new System.NotImplementedException();
        }
    }
}