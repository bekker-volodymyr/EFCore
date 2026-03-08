using Microsoft.EntityFrameworkCore;

namespace EFCore.Entities
{
    [PrimaryKey(nameof(Id))]
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<Teacher> Teachers { get; set; } = null!;
        public override string ToString()
        {
            return $"{Id}. {Name} {Description}";
        }
    }
}