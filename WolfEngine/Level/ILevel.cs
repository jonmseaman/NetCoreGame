using System.Collections.Generic;
using WolfEngine.Entiity;

namespace WolfEngine.Level
{
    /// <summary>
    /// Represents a level in game. 
    /// </summary>
    public interface ILevel
    {

        IDictionary<Location, IEnumerable<Creature>> Creatures { get; }

        /// <summary>
        /// Gets or sets the Tile at Location(x,y)
        /// </summary>
        ushort this[int x, int y] { get; set; }

        /// <summary>
        /// Gets or sets the Tile at Location
        /// </summary>
        ushort this[Location location] { get; set; }
    }
}