using System.Text.RegularExpressions;

namespace CitaviSumatraWrapper
{
    public static class ArgumentsConverter
    {
        private static readonly string AdobeArgumentSwitch = "/A";

        public static string Convert(string[] args)
        {
            if (args.Length == 0) return "";

            if (args.Length == 1) return $"\"{args[0]}\"";

            // We just handle "/A <options> <file>"
            // All other cases are just joined together
            var hasAdobeArgumentSwitch = AdobeArgumentSwitch.Equals(args[0]);
            var hasThreeArguments = args.Length == 3;
            var isNotTheHandledAdobeArgument = !(hasAdobeArgumentSwitch && hasThreeArguments);
            if (isNotTheHandledAdobeArgument) return string.Join(" ", args);

            // if no page=<number> was found, this maybePage.ToString will be empty
            var maybePageArgMatch = Regex.Match(args[1], @"page=\d+");
            var maybePage = Regex.Match(maybePageArgMatch.ToString(), @"\d+");
            var hasPageArgument = string.IsNullOrWhiteSpace(maybePage.ToString());

            var wrappedFilePath = $"\"{args[2]}\"";

            return hasPageArgument
                ? wrappedFilePath
                : $"-page {maybePage} " + wrappedFilePath;
        }
    }
}