using System.Diagnostics;

namespace CitaviSumatraWrapper
{
    public static class SumatraStarter
    {
        private static readonly string SumatraExe = @"C:\Program Files (x86)\SumatraPDF\SumatraPDF.exe";

        public static void StartSumatra(string sumatraArgs)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = SumatraExe,
                Arguments = @sumatraArgs
            };
            Process.Start(startInfo);

        }
    }
}