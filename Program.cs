using EFCore.Entities;

namespace EFCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();

            //InitializeDB(context);

            foreach(var student in context.StudentsGroups)
            {
                Console.WriteLine($"{student.StudentName} -- {student.GroupName}");
            }
        }

        static void InitializeDB(AppDbContext db)
        {
            var csharp = new Subject
            {
                Name = "C#",
                Description = ".NET and WinForms",
                Teachers = new List<Teacher>()
            };

            var databases = new Subject
            {
                Name = "Databases",
                Description = "SQL Server and EF Core",
                Teachers = new List<Teacher>()
            };

            var algebra = new Subject
            {
                Name = "Algebra",
                Description = "Linear Algebra",
                Teachers = new List<Teacher>()
            };

            var ukrainian = new Subject
            {
                Name = "Ukrainian",
                Description = "In-depth Ukrainian",
                Teachers = new List<Teacher>()
            };

            var english = new Subject
            {
                Name = "English",
                Description = "In-depth English",
                Teachers = new List<Teacher>()
            };

            var groupA = new Group
            {
                Name = "IT-101",
                Students = new List<Student>()
            };

            var groupB = new Group
            {
                Name = "MATH-202",
                Students = new List<Student>()
            };

            var groupC = new Group
            {
                Name = "DB-303",
                Students = new List<Student>()
            };

            var groupD = new Group
            {
                Name = "UKR-404",
                Students = new List<Student>()
            };

            var groupE = new Group
            {
                Name = "UKR-505",
                Students = new List<Student>()
            };

            var teacher1 = new Teacher
            {
                FirstName = "John",
                LastName = "Smith",
                BirthDate = new DateTime(1985, 4, 10),
                Salary = 3000,
                Subjects = new List<Subject> { csharp, databases }
            };

            var teacher2 = new Teacher
            {
                FirstName = "Anna",
                LastName = "Myhailivna",
                BirthDate = new DateTime(1990, 6, 22),
                Salary = 2800,
                Subjects = new List<Subject> { algebra },
            };

            var teacher3 = new Teacher
            {
                FirstName = "Michael",
                LastName = "Clear",
                BirthDate = new DateTime(1990, 6, 22),
                Salary = 2800,
                Subjects = new List<Subject> { algebra },
            };

            var teacher4 = new Teacher
            {
                FirstName = "May",
                LastName = "Brown",
                BirthDate = new DateTime(1990, 6, 22),
                Salary = 2800,
                Subjects = new List<Subject> { algebra },
            };

            var student1 = new Student
            {
                FirstName = "Alex",
                LastName = "Shevchenko",
                Email = "alex@gmail.com",
                BirthDate = new DateTime(2004, 2, 15),
                Group = groupA
            };

            var student2 = new Student
            {
                FirstName = "Maria",
                LastName = "Hvylova",
                Email = "maria@gmail.com",
                BirthDate = new DateTime(2005, 8, 5),
                Group = groupA
            };

            var student3 = new Student
            {
                FirstName = "David",
                LastName = "Kozak",
                Email = "david@gmail.com",
                BirthDate = new DateTime(2003, 11, 20),
                Group = groupB
            };

            var student4 = new Student
            {
                FirstName = "Sofia",
                LastName = "Zvychaina",
                Email = "sofia@gmail.com",
                BirthDate = new DateTime(2004, 2, 15),
                Group = groupC
            };

            var student5 = new Student
            {
                FirstName = "Kyrylo",
                LastName = "Mefodiyovich",
                Email = "kyrylo@gmail.com",
                BirthDate = new DateTime(2005, 8, 5),
                Group = groupD
            };

            var student6 = new Student
            {
                FirstName = "Myhailo",
                LastName = "Melnyk",
                Email = "myhailo@gmail.com",
                BirthDate = new DateTime(2003, 11, 20),
                Group = groupE
            };

            db.Subjects.AddRange(csharp, databases, algebra, ukrainian, english);
            db.Groups.AddRange(groupA, groupB, groupC, groupD, groupE);
            db.Teachers.AddRange(teacher1, teacher2, teacher3, teacher4);
            db.Students.AddRange(student1, student2, student3, student4, student5, student6);

            db.SaveChanges();

            Console.WriteLine("Database initialized successfully.");
        }
    }
}
