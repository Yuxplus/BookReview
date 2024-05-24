#nullable disable
using DataAccess.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class BookOwner : Record
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int OwnerId { get; set; }
        public Publisher Owner { get; set; }
    }
}
