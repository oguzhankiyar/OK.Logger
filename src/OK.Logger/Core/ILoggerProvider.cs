using System;

namespace OK.Logger
{
    public interface ILoggerProvider
    {
        void Insert(string message, string data, DateTime date);
    }
}