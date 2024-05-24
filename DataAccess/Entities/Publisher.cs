#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities.Bases;

namespace DataAccess.Entities
{
    public class Publisher: Record
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        public DateTime? EstablishmentDate { get; set; }

        public bool IsActive { get; set; }

        public decimal Score { get; set; }

        public List<BookOwner> BookOwners { get; set; }
    }
}
