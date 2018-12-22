using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CitaviSumatraWrapper
{
    public static class Logger
    {
    	private static readonly string LogDir = @"C:\Temp\";
    	private static readonly string LogFile = LogDir+"CitaviSumatraWrapper.log";

        public static void LogStartCommand(string sumatraExe, string sumatraArgs)
        {
            var date = DateTime.Now;
            
            var msg = $"{date}: \"{sumatraExe}\" {sumatraArgs}";
            Console.WriteLine(msg);
            try
            {
                TryToWriteToLogFile(msg);
            }
            catch (Exception e)
            {
                // Doesn't matter anyway
                Console.WriteLine(e);
            }
        }

        public static void TryToWriteToLogFile(string msg)
        {
            if(!Directory.Exists(LogDir)){
            	Directory.CreateDirectory(LogDir);
            }

            if(!File.Exists(LogFile)) {
            	File.Create(LogFile);
            }

            
            var readLogFileLines = File.ReadAllLines(LogFile, Encoding.UTF8).ToList();
            var readLogFileLinesCount = readLogFileLines.Count;

            var writeLogFileLines = readLogFileLines;
            if(readLogFileLinesCount > 64) {
            	writeLogFileLines = writeLogFileLines.Skip(32).ToList();
            }
            var newLogFileContent = string.Join("\n", writeLogFileLines);
            File.WriteAllText(LogFile, newLogFileContent, Encoding.UTF8);
        }


    }
}