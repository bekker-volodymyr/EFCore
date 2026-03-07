using EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class AppDbContext: DbContext
    {
        private readonly string _connectionString = "Data Source=EfCore.db";

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(_connectionString);
        }
    }
}
