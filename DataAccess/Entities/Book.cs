#nullable disable // t�m entity ve modellerde yaz�lmal�

using DataAccess.Entities.Bases

namespace DataAccess.Entities
{
    public class Book : Record
    {
        public string Title { get; set; } = null!
        
        public DateTime? PublishedYear { get; set; }
        public decimal Price { get; set; }
        // one to many k�sm� buras� one k�sm�
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}