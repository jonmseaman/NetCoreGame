using System.Collections.Generic;
using System.IO;
using System.Linq;
using MPEngine.Entity;

namespace MPEngine.Files
{
    public static class SaveData
    {
        private const string PlayerSaveLocation = "./Data/Players/";
        private const string LevelSaveLocation = "./Data/Levels/";
        private static SerializerImproved _playerSerializer;

        static SaveData()
        {
            // Make sure directories exist.
            if (!Directory.Exists(PlayerSaveLocation))
                Directory.CreateDirectory(PlayerSaveLocation);
            if (!Directory.Exists(LevelSaveLocation))
                Directory.CreateDirectory(LevelSaveLocation);
            _playerSerializer = new SerializerImproved(new[] { typeof(Player) });
        }

        public static IList<Player> LoadPlayers()
        {
            // Get list of files in PlayerSaveLocation.
            var fileList = Directory.GetFiles(PlayerSaveLocation);
            // Load the players from that file.
            var serializer = _playerSerializer;
            var players = new List<Player>(fileList.Length);
            foreach (var fileName in fileList)
            {
                var reader = File.OpenRead(fileName);
                players.Add(serializer.Deserialize<Player>(reader));
            }

            return players;
        }
    }
}