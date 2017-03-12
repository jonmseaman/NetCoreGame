using System;
using Engine.Entity;

namespace Game.UI.Controls
{
    public sealed class EnergyBar : StatBar
    {
        private Creature _creature;

        public EnergyBar(Creature c) : base(ConsoleColor.DarkGreen)
        {
            _creature = c;
            Update();
        }

        public override void Update()
        {
            StatCurrent = _creature.Attributes.Energy;
            StatMax = _creature.Attributes.MaxEnergy;
        }
    }
}