namespace MPEngine.Entity
{
    public class CreatureAttributes : Attributes
    {
        private int _health = 100;
        private int _maxHealth = 100;
        private int _energy = 100;
        private int _maxEnergy = 100;

        /// <summary>
        /// Gets or sets the amount of damage a creature can take before death.
        /// </summary>
        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                if (_health < 0) _health = 0;
                if (_health > MaxHealth) _health = MaxHealth;
            }
        }

        /// <summary>
        /// Gets or set the maximum amount of health the creature can have.
        /// </summary>
        public int MaxHealth
        {
            get { return _maxHealth; }
            set
            {
                _maxHealth = value;
                if (_maxHealth < 0) _maxHealth = 0;
            }
        }

        /// <summary>
        /// Gets or sets how much energy a creature has for abilities.
        /// </summary>
        public int Energy
        {
            get { return _energy; }
            set
            {
                _energy = value;
                if (_energy < 0) _energy = 0;
                if (_energy > MaxEnergy) _energy = MaxEnergy;
            }
        }

        /// <summary>
        /// Gets or sets the maximum amount of energy the creature can have.
        /// </summary>
        public int MaxEnergy
        {
            get { return _maxEnergy; }
            set
            {
                _maxEnergy = value;
                if (_maxEnergy < 0) _maxEnergy = 0;
            }
        }

        /// <summary>
        /// Gets or sets the experience a creature has obtained this level.
        /// </summary>
        public long Experience { get; set; }

        public int Level { get; set; } = 1;
    }
}