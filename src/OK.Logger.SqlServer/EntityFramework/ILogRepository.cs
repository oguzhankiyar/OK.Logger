namespace OK.Logger.SqlServer.EntityFramework
{
    public interface ILogRepository
    {
        void Add(LogEntity log);
    }
}