using System;

namespace CitaviSumatraWrapper
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        	Logger.Log("Original arguments:");
        	Logger.LogArguments(args);


        	var convertedArgs = ArgumentsConverter.Convert(args);
            Logger.Log("Converted argument string:");
            Logger.Log(convertedArgs);
        	

        	SumatraStarter.StartSumatra(convertedArgs);


            Logger.Log("Sumatra start command triggered. Press Enter to exit command line.");
            Console.ReadLine();
        }
    }
}