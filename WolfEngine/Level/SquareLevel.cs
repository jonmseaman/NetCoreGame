using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using WolfEngine.Entiity;

namespace WolfEngine.Level
{
    /// <summary>
    ///     Represents a square level of fixed size.
    /// </summary>
    public class SquareLevel : ILevel, IEnumerable<Location>, IEntity
    {
        private Tile[] _tiles;

        public SquareLevel(int width)
        {
            LevelWidth = width;
            CreateNewRep();
        }

        private IDictionary<Location, IList<Creature>> LocationCreaturesDictionary { get; set; }

        private IDictionary<Creature, Location> CreatureLocationDictionary { get; set; }

        /// <summary>
        ///     The width of the level.
        /// </summary>
        public int LevelWidth { get; }

        public void MoveCreature(object sender, CreatureMovedEventArgs args)
        {
            var c = (Creature)sender;

            var currentLocation = CreatureLocationDictionary[c];
            var nextLocation = Location.Add(currentLocation, args.Direction, 1);

            if (IsLocationValid(nextLocation))
            {
                Remove(c);
                Add(nextLocation, c);
            }
        }

        private bool IsLocationValid(Location loc)
        {
            var valid = 0 <= loc.X && 0 <= loc.Y
                         && loc.X < LevelWidth && loc.Y < LevelWidth;
            return valid;
        }

        #region ILevel

        public void Add(Location l, Creature c)
        {
            // Update private variables
            LocationCreaturesDictionary[l].Add(c);
            CreatureLocationDictionary.Add(c, l);

            // Observe creature events.
            c.OnMove += MoveCreature;
        }

        public bool Remove(Creature c)
        {
            var l = CreatureLocationDictionary[c];

            // Update private variables
            var removed = LocationCreaturesDictionary[l].Remove(c);
            CreatureLocationDictionary.Remove(c);

            // Stop observing creature events.
            c.HandleEvent -= EnqueueEntityEvent;

            return removed;
        }

        public IList<Creature> Creatures(Location l)
        {
            return LocationCreaturesDictionary[l];
        }

        public void Clear()
        {
            CreateNewRep();
        }

        public void Clear(Location l)
        {
            if (!LocationCreaturesDictionary.ContainsKey(l)) return;

            var list = LocationCreaturesDictionary[l];
            foreach (var c in list)
                CreatureLocationDictionary.Remove(c);

            list.Clear();
        }

        public bool Contains(Location l)
        {
            return 0 <= l.X && l.X < LevelWidth
                   && 0 <= l.Y && l.Y < LevelWidth;
        }

        public bool Contains(Creature c)
        {
            return CreatureLocationDictionary.ContainsKey(c);
        }

        /// <summary>
        ///     Gets or sets the Tile at location (x, y).
        /// </summary>
        /// <param name="x">
        /// x in interval [0, LevelWidth)
        /// </param>
        /// <param name="y">
        /// y in interval [0, LevelWidth)
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
            LocationCreaturesDictionary = new Dictionary<Location, IList<Creature>>(5);
            CreatureLocationDictionary = new Dictionary<Creature, Location>(5);

            foreach (var l in this)
                LocationCreaturesDictionary[l] = new List<Creature>();
        }

        #endregion

        #region IEnumerable

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

        #endregion

        public void Update()
        {
            // Update each entity in this
            foreach (var pair in CreatureLocationDictionary)
            {
                pair.Key.Update();
            }
        }


    }
}