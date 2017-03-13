using Engine.Entity;
using Engine.Files;
using Engine.Level;
using Xunit;

namespace Engine.Tests.Files
{
    public class SaveDataTests
    {
        [Fact]
        public void LoadPlayersTest()
        {
            var players = SaveData.LoadPlayers();
            Assert.True(players.Count >= 3);
        }

        [Fact]
        public void SavePlayerTest()
        {
            var player = new Player()
            {
                Name = "Jon",
                Location = new Location(4, 5)
            };
            SaveData.SavePlayer("Jon", player);
        }
    }
}