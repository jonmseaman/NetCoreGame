using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Mime;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace WinGame
{
    class Program
    {
        static void Main(string[] args)
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
