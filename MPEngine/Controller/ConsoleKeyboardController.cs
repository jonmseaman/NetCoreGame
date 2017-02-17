using System;
using System.Collections.Generic;
using MPEngine.Commands;

namespace WolfEngine.Controller
{
    public class ConsoleKeyboardController : IController
    {

        private HashSet<ConsoleKeyInfo> _oldKeys = new HashSet<ConsoleKeyInfo>();
        // Commands that should be activated on key press.
        private Dictionary<ConsoleKeyInfo, ICommand> _keyPressedCommands = new Dictionary<ConsoleKeyInfo, ICommand>();
        // Commands that should be activated on key release.
        private Dictionary<ConsoleKeyInfo, ICommand> _keyReleasedCommands = new Dictionary<ConsoleKeyInfo, ICommand>();


        public void ProcessUserInput()
        {
            var newSet = new HashSet<ConsoleKeyInfo>();
            while (Console.KeyAvailable) newSet.Add(Console.ReadKey(true));
            ProcessKeyPresses(_oldKeys, newSet);
            ProcessKeyReleases(_oldKeys, newSet);
            _oldKeys = newSet;
        }

        private void ProcessKeyPresses(HashSet<ConsoleKeyInfo> oldConsoleKeyet, HashSet<ConsoleKeyInfo> newSet)
        {
            foreach (var keyInfo in newSet)
            {
                ICommand cmd;
                if (!_oldKeys.Contains(keyInfo) && _keyPressedCommands.TryGetValue(keyInfo, out cmd))
                    cmd.Execute();
            }
        }

        private void ProcessKeyReleases(HashSet<ConsoleKeyInfo> oldConsoleKeyet, HashSet<ConsoleKeyInfo> newSet)
        {
            foreach (var keyInfo in _oldKeys)
            {
                ICommand cmd;
                if (!newSet.Contains(keyInfo) && _keyReleasedCommands.TryGetValue(keyInfo, out cmd))
                    cmd.Execute();
            }
        }

        #region Operations

        public void AddKeyPressedCommand(ConsoleKeyInfo key, ICommand cmd)
        {
            _keyPressedCommands.Add(key, cmd);
        }

        public void AddKeyReleasedCommand(ConsoleKeyInfo key, ICommand cmd)
        {
            _keyReleasedCommands.Add(key, cmd);
        }

        public bool RemoveKeyPressedCommand(ConsoleKeyInfo key)
        {
            return _keyPressedCommands.Remove(key);
        }

        public bool RemoveKeyReleasedCommand(ConsoleKeyInfo key)
        {
            return _keyReleasedCommands.Remove(key);
        }

        public bool HasKeyPressedCommand(ConsoleKeyInfo key)
        {
            return _keyPressedCommands.ContainsKey(key);
        }

        public bool HasKeyReleasedCommand(ConsoleKeyInfo key)
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