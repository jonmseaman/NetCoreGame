using System.Collections.Generic;
using MPEngine.Entity;
using MPGame.UI.Controls;

namespace MPGame.UI
{
    public class GameView : IComponent
    {
        private List<IComponent> _components = new List<IComponent>();

        public GameView(Creature player)
        {
            Model = new GameViewModel(player);
            _components.Add(Model.HealthBar);
            _components.Add(Model.EnergyBar);
            _components.Add(Model.StatusBar);
        }

        public GameViewModel Model { get; set; }

        public void Update()
        {
            foreach (var component in _components)
                component.Update();
        }

        public void Render()
        {
            foreach (var component in _components)
                component.Render();
        }
    }
}