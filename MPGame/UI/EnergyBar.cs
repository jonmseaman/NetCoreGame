using System;
using MPEngine.Entity;

namespace MPGame.UI
{
    public sealed class EnergyBar : StatBar, IComponent
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