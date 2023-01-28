using System;
using System.Collections.Generic;
using System.Text;

namespace TvProgram.Models.ViewModels
{
    public class DohvatiEmisijuVM
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Zanr { get; set; }
        public string TvPostaja { get; set; }
        public string Opis { get; set; }
        public DateTime DatumIVrijemePrikazivanja { get; set; }
    }
}
