using System.Collections;
using System.Collections.Generic;
using WolfEngine.Entiity;

namespace WolfEngine.Level
{
    /// <summary>
    /// Represents a square level of fixed size.
    /// </summary>
    public class SquareLevel : ILevel, IEnumerable<Location>
    {
        public SquareLevel(int width)
        {
            LevelWidth = width;
            _tiles = new Tile[width * width];
            Creatures = new Dictionary<Location, IList<Creature>>(5);
            
            foreach (Location l in this)
            {
                Creatures[l] = new List<Creature>(1);
            }
        }

        private readonly Tile[] _tiles;


        public IDictionary<Location, IList<Creature>> Creatures { get; set; }

        /// <summary>
        /// Gets or sets the Tile at location (x, y).
        /// </summary>
        /// <param name="x">0 <= x < LevelWidth</param>
        /// <param name="y">0 <= y < width</param>
        Tile ILevel.this[int x, int y]
        {
            get { return _tiles[LevelWidth * y + x]; }
            set { _tiles[LevelWidth * y + x] = value; }
        }

        /// <summary>
        /// Gets or sets the Tile at (l.X, l.Y).
        /// </summary>
        /// <param name="l">The location of the tile. <code>0 &lt;= l.Y, l.Y &lt; LevelWidth</code></param>
        Tile ILevel.this[Location l]
        {
            get { return _tiles[LevelWidth * l.Y + l.X]; }
            set { _tiles[LevelWidth * l.Y + l.X] = value; }
        }

        /// <summary>
        /// The width of the level.
        /// </summary>
        public int LevelWidth { get; }

        public IEnumerator<Location> GetEnumerator()
        {
            for (var y = 0; y < LevelWidth; y++)
            {
                for (var x = 0; x < LevelWidth; x++)
                {
                    yield return new Location(x, y);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}