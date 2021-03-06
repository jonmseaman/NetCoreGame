﻿using Engine.Level;
using Xunit;

namespace Engine.Tests.Level
{
    public class SquareLevelTests : ILevelTests
    {
        public override ILevel CreateLevel()
        {
            return new SquareLevel(5);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(1500)]
        public void TestLevelWidth(int width)
        {
            var level = new SquareLevel(width);
            Assert.Equal(width, level.LevelWidth);

            // Test contains location
            var origin = new Location(0, 0);
            Assert.True(level.Contains(origin));
            var max = level.LevelWidth - 1;
            var topRight = new Location(max, max);
            Assert.True(level.Contains(topRight));
        }
    }
}