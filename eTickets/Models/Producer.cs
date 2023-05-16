using eTickets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string ProfilePictureURL { get; set; }

        [Display (Name = "Full Name")]
        [Required(ErrorMessage ="Name is required")]
        [StringLength (50,MinimumLength =3,ErrorMessage ="Must be more than 3 words")]
        public string FullName { get; set; }

        /*[Required(ErrorMessage = "Bio is required")]*/
        public string Bio { get; set; }

        //relationships
        public List<Movie> Movies { get; set; }
    }
}
