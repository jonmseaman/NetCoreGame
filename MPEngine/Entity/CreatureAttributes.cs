namespace MPEngine.Entity
{
    public class CreatureAttributes : Attributes
    {
        /// <summary>
        /// Gets or sets the amount of damage a creature can take before death.
        /// </summary>
        public int Health { get; set; }
        public int MaxHealth { get; set; }

        /// <summary>
        /// Gets or sets how much energy a creature has for abilities.
        /// </summary>
        public int Energy { get; set; }
        public int MaxEnergy { get; set; }

        /// <summary>
        /// Gets or sets the experience a creature has obtained this level.
        /// </summary>
        public long Experience { get; set; }
        public int Level { get; set; }
    }
}