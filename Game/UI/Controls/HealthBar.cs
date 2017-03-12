using System;
using Engine.Entity;

namespace Game.UI.Controls
{
    public sealed class HealthBar : StatBar
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