namespace Engine.Level
{
    public struct Tile
    {
        /// <summary>
        /// Indicates what type of tile this is.
        /// </summary>
        public ushort TileNum;

        /// <summary>
        /// Indicatees whether a creature can walk on the tile.
        /// </summary>
        public bool IsWall;
    }
}