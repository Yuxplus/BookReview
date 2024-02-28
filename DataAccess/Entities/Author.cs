#nullable disable // tüm entity ve modellerde yazýlmalý

using DataAccess.Entities.Bases

namespace DataAccess.Entities
{
    public class Author : Record
    {
        public string Name { get; set; } = null!
        public string Surname { get; set; } = null!
        public bool IsRetired { get; set; }
        // one to many kýsmý many kýsmý
        public List<Book> Books { get; set; }
    }
}