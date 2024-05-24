using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities.Bases;

namespace DataAccess.Entities
{
    public class Book : Record
    {
        public string Title { get; set; } = null!;


        public DateTime? PublishedYear { get; set; }

        public decimal Price { get; set; }
        // one to many kısmı burası one kısmı
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public List<BookOwner> BookOwners { get; set; }
    }
}
