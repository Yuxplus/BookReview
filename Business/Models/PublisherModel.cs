using DataAccess.Entities;
using DataAccess.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class PublisherModel : Record
    {
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} must be minimum {2} and maximum {1} character! ")]
        [DisplayName("Publisher Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} must be minimum {2} and maximum {1} character! ")]
        [DisplayName("Publisher Location")]
        public string Location { get; set; }

        [DisplayName("EstablishmentDate")]
        public DateTime? EstablishmentDate { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }


		[Required(ErrorMessage = "{0} is required!")]
		[Range(0 , 5 , ErrorMessage = "{0} must be between {1} and {2}!")]
        public decimal? Score { get; set; }


        [DisplayName("Books")]
        public List<int> BookIdsInput { get; set; }


        [DisplayName("Establishmentt Date")]
        public String? EstablishmentDateOutput { get; set; }

        [DisplayName("Active")]
        public String? IsActiveOutput { get; set; }

        [DisplayName("Score")]
        public String? ScoreOutput { get; set; }
        public List<BookOwner>? BookOwners { get; internal set; }

        [DisplayName("Books")]
        public string? BookNamesOutput { get; set; }
    }
}
