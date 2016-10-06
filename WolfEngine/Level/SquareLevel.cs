using System.Collections.Generic;
using WolfEngine.Entiity;

namespace WolfEngine.Level
{
    public class SquareLevel : ILevel
    {
        public SquareLevel(int width)
        {
            _levelWidth = width;
            _tiles = new Tile[width * width];
        }

        private readonly Tile[] _tiles;

        private readonly int _levelWidth;

        public IDictionary<Location, IEnumerable<Creature>> Creatures { get; }

        Tile ILevel.this[int x, int y]
        {
            get { return _tiles[_levelWidth * y + x]; }
            set { _tiles[_levelWidth * y + x] = value; }
        }

        Tile ILevel.this[Location l]
        {
            get { return _tiles[_levelWidth * l.Y + l.X]; }
            set { _tiles[_levelWidth * l.Y + l.X] = value; }
        }
    }
}