using System.Security.Cryptography.X509Certificates;

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
    }
}