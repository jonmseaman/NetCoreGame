namespace WolfEngine.Entiity
{
    public class CreatureAttributes : Attributes
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public int Magic { get; set; }
        public int MaxMagic { get; set; }

        public long Experience { get; set; }
        public int Level { get; set; }
    }
}