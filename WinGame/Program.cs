using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace WinGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var outputDir = ".";
            var zipPath = "./Game/win10-x64.zip";
            var exe = "Game.exe";
            Console.Title = "NetCoreGame Launcher";
            if (ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.IsFirstRun
                || !File.Exists(exe) && File.Exists(zipPath))
            {
                Console.WriteLine("Running first time setup... This shouldn't last long.");
                ZipFile.ExtractToDirectory(zipPath, outputDir);
            }
            Process.Start(exe);
        }
    }
}