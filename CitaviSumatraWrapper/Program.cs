namespace CitaviSumatraWrapper
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SumatraStarter.StartSumatra(ArgumentsConverter.Convert(args));
        }
    }
}