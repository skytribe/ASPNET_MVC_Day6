using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EF_CodeFirst.Models
{

    public class Movie
    {
        public Movie()
        {
            DeleteStatus = 0;
        }

        public int Id { get; set; }

        [MinLength(1, ErrorMessage = "Title must be at least 1 character long")]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Director { get; set; }

        [DisplayName("Deletion Status")]
        public int DeleteStatus { get; set; }

    }
}
