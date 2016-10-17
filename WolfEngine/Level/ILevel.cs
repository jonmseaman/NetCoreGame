using System.Collections.Generic;
using WolfEngine.Entiity;

namespace WolfEngine.Level
{
    /// <summary>
    /// Represents a level in game. 
    /// </summary>
    public interface ILevel
    {

        void Add(Location l, Creature c);

        bool Remove(Creature c);

        IList<Creature> Creatures(Location l);

        void MoveCreature(object sender, CreatureMovedEventArgs args);

        void Clear();

        void Clear(Location l);

        bool Contains(Location l);

        bool Contains(Creature c);

        /// <summary>
        /// Gets or sets the Tile at Location(x,y)
        /// </summary>
        Tile this[int x, int y] { get; set; }

        /// <summary>
        /// Gets or sets the Tile at Location
        /// </summary>
        Tile this[Location l] { get; set; }
    }
}