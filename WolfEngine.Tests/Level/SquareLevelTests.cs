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

    }
}