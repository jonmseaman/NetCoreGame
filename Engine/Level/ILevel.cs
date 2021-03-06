﻿using System.Collections.Generic;
using Engine.Entity;

namespace Engine.Level
{
    /// <summary>
    /// Represents a level in game.
    /// </summary>
    public interface ILevel
    {
        /// <summary>
        /// A list of all the creatures in the level.
        /// </summary>
        List<Creature> Creatures { get; }

        /// <summary>
        /// Gets or sets the Tile at Location(x,y)
        /// </summary>
        Tile this[int x, int y] { get; set; }

        /// <summary>
        /// Gets or sets the Tile at Location
        /// </summary>
        Tile this[Location l] { get; set; }

        void Add(Location l, Creature c);

        bool Remove(Creature c);

        void MoveCreature(object sender, CreatureMovedEventArgs args);

        void Clear();

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
        /// Updates the entities in the level.
        /// </summary>
        void Update(GameTime gameTime);
    }
}