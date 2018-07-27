using Microsoft.EntityFrameworkCore;

namespace OK.Logger.SqlServer.EntityFramework
{
    public class LogDataContext : DbContext
    {
        private readonly string _connectionString;

        public virtual DbSet<LogEntity> Logs { get; set; }

        public LogDataContext(string connectionString) : base()
        {
            _connectionString = connectionString;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }
}