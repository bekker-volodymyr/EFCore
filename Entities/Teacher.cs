using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Entities
{
    public class Teacher
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public decimal Salary { get; set; }
        public DateTime BirthDate { get; set; }

        public List<Subject> Subjects { get; set; } = null!;

        public override string ToString()
        {
            return $"{Id}. {FirstName} {LastName} {Salary}. {Subjects.Count}";
        }
    }
}
