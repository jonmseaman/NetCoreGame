using System.Collections.Generic;
using WolfEngine.Entiity;

namespace WolfEngine.Level
{
    public class SquareLevel : ILevel
    {
        public SquareLevel(int width)
        {
            _levelWidth = width;
        }

        private Tile[] _tiles;

        private int _levelWidth;

        public IDictionary<Location, IEnumerable<Creature>> Creatures { get; }

        ushort ILevel.this[int x, int y]
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        ushort ILevel.this[Location location]
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }
    }
}