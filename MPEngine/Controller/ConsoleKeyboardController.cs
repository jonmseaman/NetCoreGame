using System;
using System.Collections.Generic;
using MPEngine.Commands;

namespace MPEngine.Controller
{
    public class ConsoleKeyboardController : IController
    {
        // Commands that should be activated on key press.
        private Dictionary<ConsoleKey, ICommand> _keyPressedCommands = new Dictionary<ConsoleKey, ICommand>();
        // Commands that should be activated on key release.
        private Dictionary<ConsoleKey, ICommand> _keyReleasedCommands = new Dictionary<ConsoleKey, ICommand>();

        private static HashSet<ConsoleKeyInfo> _oldKeys = new HashSet<ConsoleKeyInfo>();
        private static HashSet<ConsoleKeyInfo> _newKeys = new HashSet<ConsoleKeyInfo>();
        private static DateTime _lastTime = DateTime.Now;


        public void ProcessUserInput(GameTime gameTime)
        {
            GetNewKeySet(gameTime.Time);
            ProcessKeyPresses(_oldKeys, _newKeys);
            ProcessKeyReleases(_oldKeys, _newKeys);
        }

        private static void GetNewKeySet(DateTime time)
        {
            if (_lastTime >= time) return;
            var newSet = new HashSet<ConsoleKeyInfo>();
            while (Console.KeyAvailable) newSet.Add(Console.ReadKey(true));
            _oldKeys = _newKeys;
            _newKeys = newSet;
            _lastTime = time;
        }

        private void ProcessKeyPresses(HashSet<ConsoleKeyInfo> oldSet, HashSet<ConsoleKeyInfo> newSet)
        {
            foreach (var keyInfo in newSet)
                if (!oldSet.Contains(keyInfo) && _keyPressedCommands.TryGetValue(keyInfo.Key, out ICommand cmd))
                    cmd.Execute();
        }

        private void ProcessKeyReleases(HashSet<ConsoleKeyInfo> oldSet, HashSet<ConsoleKeyInfo> newSet)
        {
            foreach (var keyInfo in oldSet)
                if (!newSet.Contains(keyInfo) && _keyReleasedCommands.TryGetValue(keyInfo.Key, out ICommand cmd))
                    cmd.Execute();
        }

        #region Operations

        public void AddKeyPressedCommand(ConsoleKey key, ICommand cmd)
        {
            _keyPressedCommands.Add(key, cmd);
        }

        public void AddKeyReleasedCommand(ConsoleKey key, ICommand cmd)
        {
            _keyReleasedCommands.Add(key, cmd);
        }

        public bool RemoveKeyPressedCommand(ConsoleKey key)
        {
            return _keyPressedCommands.Remove(key);
        }

        public bool RemoveKeyReleasedCommand(ConsoleKey key)
        {
            return _keyReleasedCommands.Remove(key);
        }

        public bool HasKeyPressedCommand(ConsoleKey key)
        {
            return _keyPressedCommands.ContainsKey(key);
        }

        public bool HasKeyReleasedCommand(ConsoleKey key)
        {
            return _keyReleasedCommands.ContainsKey(key);
        }

        public void Clear()
        {
            _keyPressedCommands.Clear();
            _keyReleasedCommands.Clear();
        }

        #endregion
    }
}