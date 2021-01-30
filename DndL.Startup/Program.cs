using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace DndL.Startup
{
    class Program
    {
        const string guipath
                    = @"C:\Users\euan\source\repos\DndLocal\DndL.Gui\bin\Debug\net5.0-windows\DndL.Gui.exe";
        static readonly CancellationTokenSource tokenSrc = new();
        
        public static void Main(string[] args)
        {


            Task.Run(async () =>
            {
                using (var proc = new Process())
                {
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.FileName = guipath;
                    proc.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(guipath);

                    //proc.Start();

                    await proc.WaitForExitAsync(tokenSrc.Token);
                }
            });

            Console.ReadKey();
        }

    }
}
