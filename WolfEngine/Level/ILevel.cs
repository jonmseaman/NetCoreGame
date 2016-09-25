using System.Collections.Generic;
using WolfEngine.Entiity;

namespace WolfEngine.Level
{
    /// <summary>
    /// Represents a level in game. 
    /// </summary>
    public interface ILevel
    {
        Dictionary<Location, IEnumerable<Creature>> Creatures { get; }

        // Tiles
        // Indexor to add tiles?
        // API for getting and setting nodes / tiles.
        int this[int x, int y] { get; set; }
        int this[Location location] { get; set; }
    }
}