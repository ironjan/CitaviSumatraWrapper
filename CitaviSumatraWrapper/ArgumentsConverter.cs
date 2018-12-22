using System;
using System.Text.RegularExpressions;

namespace CitaviSumatraWrapper
{
    public class ArgumentsConverter
    {
        public static string Convert(string[] args)
        {
            if (args.Length == 0)
            {
                return "";
            }

            if ("/A".Equals(args[0]) && args.Length == 2)
            {
                return args[1];
            }

            if ("/A".Equals(args[0])){
                var filePath = args[2];
                var maybePageArgMatch = Regex.Match(args[1], @"page=\d+");
                var maybePage = Regex.Match(maybePageArgMatch.ToString(), @"\d+");
                return string.IsNullOrWhiteSpace(maybePage.ToString()) 
                    ? $"\"{filePath}\"" 
                    : $"-page {maybePage} \"{filePath}\"";
            }

            return string.Join(" ", args);
        }
    }
}