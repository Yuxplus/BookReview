using DataAccess.Entities.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Business.Models
{
    public class BookModel : Record
    {
        #region Entity Properties
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} must be minimum {2} and maximum {1} character! ")]
        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Publish Year")]
        public DateTime? PublishedYear { get; set; }

        [DisplayName("Price")]
        public decimal Price { get; set; }
        // one to many kısmı burası one kısmı
        public int AuthorId { get; set; }

        //public required Author Author { get; set; }
        #endregion
    }
}
