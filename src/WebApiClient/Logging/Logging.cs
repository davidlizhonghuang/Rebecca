using Microsoft.Extensions.Logging;

namespace ContactWebApITest.Logging
{
        public static class ApplicationLogging
    {
        public static ILoggerFactory LoggerFactory { get; } = new LoggerFactory();
        public static ILogger CreateLogger<T>() =>
          LoggerFactory.CreateLogger<T>();
    }



    public enum LogLevel
    {
        Debug = 1,
        Verbose = 2,
        Information = 3,
        Warning = 4,
        Error = 5,
        Critical = 6,
        None = int.MaxValue
    }

    public class LoggingEvents

    {

        public const int GENERATE_ITEMS = 1000;

        public const int LIST_ITEMS = 1001;

        public const int GET_ITEM = 1002;

        public const int INSERT_ITEM = 1003;

        public const int UPDATE_ITEM = 1004;

        public const int DELETE_ITEM = 1005;



        public const int GET_ITEM_NOTFOUND = 4000;

        public const int UPDATE_ITEM_NOTFOUND = 4001;

    }


}
