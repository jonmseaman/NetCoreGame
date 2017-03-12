using Engine.Files;
using Xunit;

namespace Engine.Tests.Files
{
    public class SaveDataTests
    {
        [Fact]
        public void LoadPlayersTest()
        {
            var players = SaveData.LoadPlayers();
            Assert.True(players.Count == 3);
        }
    }
}