using WolfEngine.Entity;
using Xunit;

namespace WolfEngine.Tests.Entity
{
    public class InventoryTests : IInventoryTests
    {
        #region IInventoryTests

        public override IInventory NewInstance(int capacity)
        {
            return new Inventory(capacity);
        }

        #endregion

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(20)]
        public void TestInventoryConstructor(int capacity)
        {
            var inv = NewInstance(capacity);
            Assert.Equal(0, inv.Size);
            Assert.Equal(capacity, inv.Capacity);
            Assert.Equal(true, inv.Empty);
            Assert.Equal(capacity == 0, inv.Full);
        }
    }
}