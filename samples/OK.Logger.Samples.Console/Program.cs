using OK.Logger;
using OK.Logger.SqlServer;

namespace OK.Logger.Samples.Console
{
    class Program
    {
        private static ILogger _logger = Logger.New((config) =>
        {
            config.UseSqlServer("Server=OKCOMPUTER;Database=OK.Logger;Trusted_Connection=True;MultipleActiveResultSets=True;")
                  .EnableInternalLog("C:\\oklogger-internal.txt");
        });

        static void Main(string[] args)
        {
            _logger.Add("App is started.");

            WriteLine("Type a message!");

            string message = ReadLine();

            _logger.Add(message);

            _logger.Add("App is finished.");
        }

        static void WriteLine(string value) => System.Console.WriteLine(value);
        static string ReadLine() => System.Console.ReadLine();
    }
}
