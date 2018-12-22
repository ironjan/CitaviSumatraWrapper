using System;
using System.Diagnostics;

namespace CitaviSumatraWrapper
{
    public static class SumatraStarter
    {
        private static readonly string SumatraExe = @"C:\Program Files (x86)\SumatraPDF\SumatraPDF.exe";

        public static void StartSumatra(string sumatraArgs)
        {
            /*
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = SumatraExe;
            startInfo.Arguments = sumatraArgs;
            Process.Start(startInfo);
            */

            Logger.LogStartCommand(SumatraExe, sumatraArgs);
        }
    }
}