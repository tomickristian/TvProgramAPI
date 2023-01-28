using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvProgram.Models
{
    public class Emisija
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }
        [Required]
        public int ZanrId { get; set; }
        [Required]
        public int TvPostajaId { get; set; }
        [Required]
        [StringLength(200)]
        public string Opis { get; set; }
        [Required]
        public DateTime DatumIVrijemePrikazivanja { get; set; }
    }
}
