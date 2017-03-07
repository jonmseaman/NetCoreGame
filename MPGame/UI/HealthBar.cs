using System;
using MPEngine.Entity;

namespace MPGame.UI
{
    public sealed class HealthBar : StatBar, IComponent
    {
        private Creature _creature;

        public HealthBar(Creature c) : base(ConsoleColor.DarkRed)
        {
            _creature = c;
            Update();
        }

        public override void Update()
        {
            StatCurrent = _creature.Attributes.Health;
            StatMax = _creature.Attributes.MaxHealth;
        }
    }
}