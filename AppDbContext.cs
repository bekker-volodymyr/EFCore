using EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class AppDbContext: DbContext
    {
        //private readonly string _connectionString = "Data Source=EfCore.db";
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EfCore;";

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlite(_connectionString);
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().Property(s => s.Scholarship).HasColumnType("money");
        }
    }
}
