using eTickets.Data.Base;
using eTickets.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class NewMovieVM 
    {
        [Key]
        public int Id { get; set; }

        [Display(Description = "نام فیلم")]
        [Required(ErrorMessage ="ورود نام اجباری است")]
        public string Name { get; set; }
        [Required(ErrorMessage = "ورود توضیح  اجباری است")]
        public string Description { get; set; }
        [Required(ErrorMessage = "ورود قیمت اجباری است")]
        public double Price { get; set; }
        [Required(ErrorMessage = "ورود آدرس عکس اجباری است")]
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        public List<int> ActorIds { get; set; }

        public int CinemaId { get; set; }

        public int ProducerId { get; set; }

    }
}
