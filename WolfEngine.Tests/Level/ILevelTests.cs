using WolfEngine.Entity;
using WolfEngine.Level;
using Xunit;

namespace WolfEngine.Tests.Level
{
    // ReSharper disable once InconsistentNaming
    public abstract class ILevelTests
    {
        public abstract ILevel CreateLevel();

        [Fact]
        public void TestAddCreature()
        {
            var level = CreateLevel();
            var l = new Location(2, 3);
            var c = new Creature();

            level.Add(l, c);
            Assert.True(level.Contains(c));
        }

        [Fact]
        public void TestMoveCreature()
        {
            var level = CreateLevel();
            var l = new Location(2, 3);
            var to = Location.Add(l, Direction.North, 1);
            var c = new Creature();

            level.Add(l, c);
            c.Move(Direction.North);
            Assert.Equal(to, c.Location);
        }
    }
}