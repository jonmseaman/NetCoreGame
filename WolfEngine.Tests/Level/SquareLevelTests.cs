using WolfEngine.Entiity;
using WolfEngine.Level;
using Xunit;

namespace WolfEngine.Tests.Level
{
    public class SquareLevelTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(1500)]
        public void TestLevelWidth(int width)
        {
            var level = new SquareLevel(width);
            Assert.Equal(width, level.LevelWidth);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(256, 0)]
        [InlineData(0, 256)]
        public void TestCreaturesAddFromEmpty(int x, int y)
        {
            var level = new SquareLevel(256);
            var l = new Location(x, y);
            level.Creatures[l].Add(new Creature());

            Assert.NotNull(level.Creatures[l]);
            Assert.Equal(1, level.Creatures[l].Count);
        }

    }
}