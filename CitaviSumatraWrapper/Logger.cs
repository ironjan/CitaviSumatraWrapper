using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CitaviSumatraWrapper
{
    public static class Logger
    {
        private static readonly string LogDir = @"C:\Temp\";
        private static readonly string LogFile = LogDir + "CitaviSumatraWrapper.log";

        private static readonly int LogFileMaxLinesCount = 64;
        private static readonly int LogFileSkipLinesCount = 32;

        public static void LogOriginalArguments(string[] args){
            PrintAndWriteToFile(args.Length + " arguments: " + string.Join(" ", args));
        }

        public static void LogStartCommand(string sumatraExe, string sumatraArgs)
        {
            PrintAndWriteToFile($"\"{sumatraExe}\" {sumatraArgs}");
        }

        private static void PrintAndWriteToFile(string untimedMsg)
        {
            var msg = $"{AssemblyInfo.AppName} - {DateTime.Now}: {untimedMsg}";

            Console.WriteLine(msg);

            try
            {
                TryToWriteToLogFile(msg);
            }
            catch (Exception e)
            {
                // Doesn't matter anyway - usually won't be displayed
                Console.WriteLine(e);
            }
        }

        private static void TryToWriteToLogFile(string msg)
        {
            if (!Directory.Exists(LogDir)) Directory.CreateDirectory(LogDir);

            if (!File.Exists(LogFile)) File.Create(LogFile);

            var currentLogFileLines = File.ReadAllLines(LogFile, Encoding.UTF8).ToList();

            var doesLogFileNeedTrimming = currentLogFileLines.Count > LogFileMaxLinesCount;
            var numberOfLinesToRemove = doesLogFileNeedTrimming ? LogFileSkipLinesCount : 0;

            var writeLogFileLines = new List<string>();
            writeLogFileLines.AddRange(currentLogFileLines.Skip(numberOfLinesToRemove));
            writeLogFileLines.Add(msg);

            var newLogFileContent = string.Join("\n", writeLogFileLines);

            File.WriteAllText(LogFile, newLogFileContent, Encoding.UTF8);
        }
    }
}