using DataAccess.Entities.Bases;
#nullable disable

namespace DataAccess.Entities
{
    public class Author : Record
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public bool IsRetired { get; set; }
        // one to many kısmı many kısmı
        public List<Book> Books { get; set; }

    }
}
