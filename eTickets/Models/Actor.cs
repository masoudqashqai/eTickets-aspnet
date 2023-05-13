using eTickets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture URL")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Full name is Required")]
        [StringLength(50,MinimumLength =2, ErrorMessage ="Name must be between 2 and 50 chars")]
        public string FullName { get; set; }

        [Display(Name = "Bio")]
        [Required(ErrorMessage = "Bio is Required")]
        public string Bio{ get; set; }

        //relationships
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
