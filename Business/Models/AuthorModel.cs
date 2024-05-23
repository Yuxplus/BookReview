using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable
using DataAccess.Entities.Bases;
namespace Business.Models
{
    public class AuthorModel : Record
    {
        #region Entity Properties
        [Required(ErrorMessage ="{0} is required!")]
        [StringLength(50,MinimumLength =2,ErrorMessage = "{0} must be minimum {2} and maximum {1} character! ")]
        [DisplayName("Author Name")]
        public string Name { get; set; } = null!;



        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} must be minimum {2} and maximum {1} character! ")]
        [DisplayName("Author Surname")]
        public string Surname { get; set; } = null!;



        [DisplayName("Is Retire")]
        public bool IsRetired {  get; set; } = false;



        [DisplayName("Books' Names")]
        public string BookNamesOutput { get; set; }
        #endregion

        #region
        [DisplayName("Author Count")]
        public int AuthorCountOutput { get; set; }
        #endregion
    }
}
