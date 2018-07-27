namespace OK.Logger.SqlServer.EntityFramework
{
    public class LogRepository : ILogRepository
    {
        private readonly LogDataContext _context;

        public LogRepository(LogDataContext context)
        {
            _context = context;
        }

        public void Add(LogEntity log)
        {
            _context.Add(log);

            _context.SaveChanges();
        }
    }
}