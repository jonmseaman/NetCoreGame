using WolfEngine.Entiity;
using Xunit;

namespace WolfEngine.Tests.Entity
{
    // ReSharper disable once InconsistentNaming
    public abstract class IInventoryTests
    {
        public abstract IInventory NewInstance(int capacity);

        /// <summary>
        /// Creates a new inventory with <see cref="size"/> items.
        /// </summary>
        /// <param name="size">The number of items to be put in inv.</param>
        /// <param name="capacity">The capacity of the new inventory.</param>
        /// <returns>A new inventory with the corresponding size and capacity.</returns>
        private IInventory FillInventoryToSize(int size, int capacity)
        {
            var inv = NewInstance(capacity);
            for (var i = 0; i < size; ++i)
            {
                inv.Add(new Item());
            }

            return inv;
        }

        #region Properties

        // TODO: Test the indexer.

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 2)]
        [InlineData(1, 2)]
        [InlineData(8, 8)]
        public void TestInventorySize(int size, int capacity)
        {
            var inv = FillInventoryToSize(size, capacity);
            Assert.Equal(size, inv.Size);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 2)]
        [InlineData(1, 2)]
        [InlineData(8, 8)]
        public void TestInventoryCapacity(int size, int capacity)
        {
            var inv = FillInventoryToSize(size, capacity);
            Assert.Equal(capacity, inv.Capacity);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 2)]
        [InlineData(1, 2)]
        [InlineData(8, 8)]
        public void TestEmpty(int size, int capacity)
        {
            var inv = FillInventoryToSize(size, capacity);
            Assert.Equal(0 == size, inv.Empty);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 2)]
        [InlineData(2, 2)]
        [InlineData(8, 8)]
        public void TestFull(int size, int capacity)
        {
            var inv = FillInventoryToSize(size, capacity);
            Assert.Equal(capacity == size, inv.Full);
        }
        #endregion

        [Fact]
        public void TestInventoryAddWhenEmpty()
        {
            var inv = FillInventoryToSize(0, 8);
            var added = inv.Add(new Item());
            Assert.True(added);
            Assert.Equal(1, inv.Size);
        }

        [Fact]
        public void TestInventoryAddWhenFull()
        {
            var inv = FillInventoryToSize(8, 8);
            var added = inv.Add(new Item());
            Assert.False(added);
            Assert.Equal(8, inv.Size);
        }

        [Fact]
        public void TestAddAtWhenEmpty()
        {
            var inv = FillInventoryToSize(0, 8);
            inv.AddAt(new Item(), 0);
        }

        [Fact]
        public void TestAddAtToFull()
        {
            var inv = FillInventoryToSize(0, 8);
            for (var i = 0; i < 8; i++)
            {
                var added = inv.AddAt(new Item(), i);
                Assert.True(added);
            }
        }

        [Fact]
        public void TestAddAtWhenFull()
        {
            // Build a full inventory.
            var inv = FillInventoryToSize(8, 8);

            // Test adding when the slot is taken:
            for (var i = 0; i < 8; i++)
            {
                var added = inv.AddAt(new Item(), 0);
                Assert.False(added);
            }
        }

        [Theory]
        [InlineData(0, 8)]
        [InlineData(3, 8)]
        [InlineData(8, 8)]
        public void TestClear(int size, int capacity)
        {
            var inv = FillInventoryToSize(size, capacity);
            inv.Clear();
            Assert.Equal(0, inv.Size);
        }

        [Fact]
        public void TestRemoveWhenEmpty()
        {
            var inv = FillInventoryToSize(0, 8);
            var removed = inv.Remove(new Item());
            Assert.False(removed);
        }

        [Fact]
        public void TestRemoveWhenFull()
        {
            int invSize = 8;
            Item[] items = new Item[invSize];
            var inv = new Inventory(invSize);

            // Get some items to add to the inventory.
            for (int i = 0; i < invSize; i++)
            {
                items[i] = new Item();
            }

            // Add items
            for (int i = 0; i < invSize; i++)
            {
                inv.Add(items[i]);
            }

            // Remove items
            for (int i = 0; i < invSize; i++)
            {
                var removed = inv.Remove(items[i]);
                Assert.True(removed);
            }

            Assert.Equal(0, inv.Size);
        }

        [Fact]
        public void TestRemoveAtWhenEmpty()
        {
            var inv = FillInventoryToSize(0, 8);
            for (int i = 0; i < 8; i++)
            {
                var removed = inv.RemoveAt(i);
                Assert.False(removed);
            }
            Assert.Equal(0, inv.Size);
        }

        [Fact]
        public void TestRemoveAtWhenFull()
        {
            var inv = FillInventoryToSize(8, 8);
            for (int i = 0; i < 8; i++)
            {
                var removed = inv.RemoveAt(i);
                Assert.True(removed);
            }
            Assert.Equal(0, inv.Size);
        }
    }
}