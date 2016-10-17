﻿using System.Collections.Generic;
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

        /// <summary>
        /// Removes Creatures from location l.
        /// </summary>
        /// <param name="l">The location which Creatures will be removed from.</param>
        void Clear(Location l);

        /// <summary>
        /// Checks if a location l is part of the level.
        /// </summary>
        /// <returns>True if the location is part of the level.</returns>
        bool Contains(Location l);

        /// <summary>
        /// Checks if a creature c is part of the level.
        /// </summary>
        /// <returns>True if c is in the level.</returns>
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