using System;
using System.Collections;
using System.Collections.Generic;
using WolfEngine.Entiity;

namespace WolfEngine.Level
{
    /// <summary>
    ///     Represents a square level of fixed size.
    /// </summary>
    public class SquareLevel : ILevel, IEnumerable<Location>
    {
        private Tile[] _tiles;

        public SquareLevel(int width)
        {
            LevelWidth = width;
            CreateNewRep();
        }

        private IDictionary<Location, IList<Creature>> Creatures { get; set; }

        private IDictionary<Creature, Location> CreatureLocations { get; set; }

        /// <summary>
        ///     The width of the level.
        /// </summary>
        public int LevelWidth { get; }

        public IEnumerator<Location> GetEnumerator()
        {
            for (var y = 0; y < LevelWidth; y++)
                for (var x = 0; x < LevelWidth; x++)
                    yield return new Location(x, y);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Location l, Creature c)
        {
            // Update private variables
            Creatures[l].Add(c);
            CreatureLocations.Add(c, l);

            // Observe creature.
            c.Moved += MoveCreature;
        }

        public bool Remove(Creature c)
        {
            var l = CreatureLocations[c];

            // Update private variables
            var removed = Creatures[l].Remove(c);
            CreatureLocations.Remove(c);

            // Stop observing creature.
            c.Moved -= MoveCreature;

            return removed;
        }

        IList<Creature> ILevel.Creatures(Location l)
        {
            return Creatures[l];
        }

        public void MoveCreature(object sender, CreatureMovedEventArgs args)
        {
            var c = (Creature) sender;

            var currentLocation = CreatureLocations[c];
            var nextLocation = Location.Add(currentLocation, args.Direction, 1);

            Remove(c);
            Add(nextLocation, c);
        }

        public void Clear()
        {
            CreateNewRep();
        }

        public void Clear(Location l)
        {
            if (!Creatures.ContainsKey(l)) return;

            var list = Creatures[l];
            foreach (var c in list)
                CreatureLocations.Remove(c);

            list.Clear();
        }

        public bool Contains(Location l)
        {
            return 0 <= l.X && l.X < LevelWidth
                   && 0 <= l.Y && l.Y < LevelWidth;
        }

        public bool Contains(Creature c)
        {
            return CreatureLocations.ContainsKey(c);
        }

        /// <summary>
        ///     Gets or sets the Tile at location (x, y).
        /// </summary>
        /// <param name="x">
        ///     0 <= x < LevelWidth
        /// </param>
        /// <param name="y">
        ///     0 <= y < width
        /// </param>
        Tile ILevel.this[int x, int y]
        {
            get { return _tiles[LevelWidth*y + x]; }
            set { _tiles[LevelWidth*y + x] = value; }
        }

        /// <summary>
        ///     Gets or sets the Tile at (l.X, l.Y).
        /// </summary>
        /// <param name="l">The location of the tile. <code>0 &lt;= l.Y, l.Y &lt; LevelWidth</code></param>
        Tile ILevel.this[Location l]
        {
            get { return _tiles[LevelWidth*l.Y + l.X]; }
            set { _tiles[LevelWidth*l.Y + l.X] = value; }
        }

        private void CreateNewRep()
        {
            _tiles = new Tile[LevelWidth*LevelWidth];
            Creatures = new Dictionary<Location, IList<Creature>>(5);
            CreatureLocations = new Dictionary<Creature, Location>(5);

            foreach (var l in this)
                Creatures[l] = new List<Creature>();
        }
    }
}