using System.Reflection;
using EfCoreTask.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace EfCoreTask.Data
{
    public class TeamDbContext : DbContext
    {
        private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        private readonly bool _isLoggerEnabled = false;

        public TeamDbContext()
        {
            
        }
        public TeamDbContext(bool isLoggerEnabled = false)
        {
            _isLoggerEnabled = isLoggerEnabled;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (_isLoggerEnabled)
            {
                optionsBuilder.UseLoggerFactory(_loggerFactory)
                    .EnableSensitiveDataLogging();
            }

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=team.db", options =>
                    {
                        options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                    })
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
    }
}
