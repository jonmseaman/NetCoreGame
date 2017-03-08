using System;
using System.Collections.Generic;
using MPEngine.Entity;

namespace MPGame.UI
{
    class MainView : IComponent
    {
        List<IComponent> _components = new List<IComponent>();

        public MainView(Creature player)
        {
            Model = new MainViewModel(player);
            _components.Add(Model.HealthBar);
            _components.Add(Model.EnergyBar);
            _components.Add(Model.StatusBar);
        }

        public MainViewModel Model { get; set; }

        public void Update()
        {
            foreach (var component in _components)
            {
                component.Update();
            }
        }

        public void Render()
        {
            foreach (var component in _components)
            {
                component.Render();
            }
        }
    }
}
