﻿using System.Collections;
using System.Collections.Generic;
using Engine.Entity;

namespace Engine.Level
{
    /// <summary>
    /// Represents a square level of fixed size.
    /// </summary>
    public class SquareLevel : GameObject, ILevel, IEnumerable<Location>
    {
        private Tile[] _tiles;

        public SquareLevel(int width)
        {
            LevelWidth = width;
            CreateNewRep();
        }

        /// <summary>
        /// The width of the level.
        /// </summary>
        public int LevelWidth { get; }

        /// <summary>
        /// Contains all the creatures in the level.
        /// </summary>
        public List<Creature> Creatures { get; } = new List<Creature>();

        public void MoveCreature(object sender, CreatureMovedEventArgs args)
        {
            var c = sender as Creature;
            if (c == null) return;

            // Keep the creature in the level.
            var x = c.Location.X;
            c.Location.X = x < 0 ? 0 : c.Location.X;
            c.Location.X = x >= LevelWidth ? LevelWidth - 1 : c.Location.X;

            var y = c.Location.Y;
            c.Location.Y = y < 0 ? 0 : c.Location.Y;
            c.Location.Y = y >= LevelWidth ? LevelWidth - 1 : c.Location.Y;
        }

        #region GameObject

        public override void Update(GameTime gameTime)
        {
            // Update each entity in this
            foreach (var creature in Creatures)
                creature.Update(gameTime);
        }

        #endregion

        public Tile GetTile(int x, int y)
        {
            return _tiles[LevelWidth * y + x];
        }

        #region ILevel

        public void Add(Location l, Creature c)
        {
            // Update private variables
            Creatures.Add(c);
            c.Location = l;

            // Observe creature events.
            c.OnMove += MoveCreature;
        }

        public bool Remove(Creature c)
        {
            var removed = Creatures.Remove(c);

            // Stop observing creature events.
            c.OnMove -= MoveCreature;

            return removed;
        }

        public void Clear()
        {
            CreateNewRep();
        }

        public bool Contains(Location l)
        {
            return 0 <= l.X && l.X < LevelWidth
                   && 0 <= l.Y && l.Y < LevelWidth;
        }

        public bool Contains(Creature c)
        {
            return Creatures.Contains(c);
        }

        /// <summary>
        /// Gets or sets the Tile at location (x, y).
        /// </summary>
        /// <param name="x">
        /// x in interval [0, LevelWidth)
        /// </param>
        /// <param name="y">
        /// y in interval [0, LevelWidth)
        /// </param>
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

        private void CreateNewRep()
        {
            _tiles = new Tile[LevelWidth * LevelWidth];
            Creatures.Capacity = 0;
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
    }
}