using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MissionAssignment4.Models
{
    public class MovieApplicationResponse
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1800, 2022)]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }



    }
}
