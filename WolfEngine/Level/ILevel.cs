using System.Collections.Generic;
using WolfEngine.Entiity;

namespace WolfEngine.Level
{
    /// <summary>
    /// Represents a level in game. 
    /// </summary>
    public interface ILevel
    {

        /// <summary>
        /// The creatures in the level by Location.
        /// </summary>
        IDictionary<Location, IList<Creature>> Creatures { get; }

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