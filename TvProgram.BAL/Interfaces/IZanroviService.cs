using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvProgram.Models;
using TvProgram.Models.ViewModels;

namespace TvProgram.BAL.Interfaces
{
    public interface IZanroviService
    {
        List<Zanr> DohvatiZanrove(int TvPostajaId);
        Task<bool> DodajZanr(DodajIliUrediZanrVM model);
        Task<bool> UrediZanr(DodajIliUrediZanrVM model, int ZanrId);
        Task<bool> UkloniZanr(int ZanrId);
    }
}
