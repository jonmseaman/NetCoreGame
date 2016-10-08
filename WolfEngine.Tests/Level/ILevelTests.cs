using WolfEngine.Entiity;
using WolfEngine.Level;
using Xunit;

namespace WolfEngine.Tests.Level
{
    // ReSharper disable once InconsistentNaming
    public abstract class ILevelTests
    {
        [Fact]
        public void TestCreaturesAddFromEmpty()
        {
            var level = new SquareLevel(256);
            var l = new Location(5, 8);
            level.Creatures[new Location(5, 5)].Add(new Creature());
            
            Assert.NotNull(level.Creatures[l]);
            Assert.Equal(1, level.Creatures[l].Count);
        }

        [Fact]
        public void TestCreatureAddFromEmpty()
        {
            
        }

        [Fact]
        public void TestIndexorIntIntGet()
        {
            
        }

        [Fact]
        public void TestIndexorIntIntSet()
        {
            
        }

        [Fact]
        public void TestIndexorLocationGet()
        {
            
        }

        [Fact]
        public void TestIndexorLocationSetWhenEmpty()
        {
            
        }
    }
}