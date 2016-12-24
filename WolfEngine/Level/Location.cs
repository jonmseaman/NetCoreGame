namespace WolfEngine.Level
{
    /// <summary>
    /// Represents a location in a level.
    /// </summary>
    public struct Location
    {
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public static Location Add(Location start, Direction dir, int distance)
        {
            var end = start;
            switch (dir)
            {
                case Direction.North:
                    end.Y += distance;
                    break;
                case Direction.East:
                    end.X += distance;
                    break;
                case Direction.South:
                    end.Y -= distance;
                    break;
                case Direction.West:
                    end.X -= distance;
                    break;
                case Direction.None:
                default:
                    // Nothing to do.
                    break;
            }

            return end;
        }
    }
}