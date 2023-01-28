using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvProgram.Models
{
    public class Zanr
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Naziv { get; set; }
    }
}
