using EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.JavaScript;

namespace EFCore
{
    public class AppDbContext: DbContext
    {
        //private readonly string _connectionString = "Data Source=EfCore.db";
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EfCore;";

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlite(_connectionString);
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Student>().Property(s => s.Scholarship).HasColumnType("money");
            modelBuilder.Entity<Teacher>(b =>
            {
                b.Property(t => t.Salary)
                    .HasColumnType("money")
                    .HasDefaultValue(25_000);
                b.ToTable(t => t.HasCheckConstraint("CK_Salary_MoreThenZero", "[Salary] > 0"));
            });

            modelBuilder.Entity<Student>(b =>
            {
                b.Property(s => s.Scholarship).HasColumnType("money");
                b.HasIndex(s => s.Email).IsUnique();
                b.ToTable(s => s.HasCheckConstraint("CK_Email_Pattern", "[Email] LIKE '%_@%_.%_'"));
                b.Property(s => s.AttendanceForm).HasConversion<string>();
                b.ToTable(s => s.HasCheckConstraint("CK_AttendanceForms", "[Attendance] IN ('Hybrid', 'Offline', 'Online')"));
                b.HasOne(s => s.Passport).WithOne(p => p.Student).HasForeignKey<Passport>(p => p.StudentId);
            });

            modelBuilder.Entity<Group>(g =>
            {
                g.HasIndex(nameof(Group.Name)).IsUnique();
            });
        }
    }
}
