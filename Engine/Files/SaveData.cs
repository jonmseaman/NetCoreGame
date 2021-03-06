﻿using System.Collections.Generic;
using System.IO;
using Engine.Entity;

namespace Engine.Files
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
            _playerSerializer = new SerializerImproved(new[] {typeof(Player)});
        }

        public static IList<Player> LoadPlayers()
        {
            // Get list of files in PlayerSaveLocation.
            var fileList = Directory.GetFiles(PlayerSaveLocation);
            // Load the players from that file.
            var serializer = _playerSerializer;
            var players = new List<Player>(fileList.Length);
            foreach (var fileName in fileList)
                using (var reader = File.OpenRead(fileName))
                {
                    players.Add(serializer.Deserialize<Player>(reader));
                }

            return players;
        }

        public static void SavePlayer(string fileName, Player player)
        {
            var serializer = _playerSerializer;
            var filePath = Path.Combine(PlayerSaveLocation, fileName);
            filePath = Path.ChangeExtension(filePath, "xml");
            using (var writer = File.OpenWrite(filePath))
            {
                serializer.Serialize(writer, player);
            }
        }
    }
}