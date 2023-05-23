using eTickets.Models;
using System.Collections.Generic;

namespace eTickets.Data.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public NewMovieDropdownsVM()
        {
            producers = new List<Producer>();
            cinemas = new List<Cinema>();
            actors = new List<Actor>();
        }

        public List<Producer> producers { get; set; }
        public List<Cinema> cinemas { get; set; }
        public List<Actor> actors { get; set; }
    }
}
