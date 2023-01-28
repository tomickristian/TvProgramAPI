using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvProgram.Models;
using TvProgram.Models.ViewModels;

namespace TvProgram.DAL.Repository.Interfaces
{
    public interface IZanroviRepository
    {
        List<Zanr> DohvatiZanrove(int TvPostajaId);
        List<Zanr> DohvatiSveZanrove();
        Zanr DohvatiZanr(int ZanrId);
        Task<bool> DodajZanr(DodajIliUrediZanrVM model);
        Task<bool> UrediZanr(DodajIliUrediZanrVM model, int ZanrId);
        Task<bool> UkloniZanr(int ZanrId);
        bool PostojanostZanra(string Naziv);
        bool PostojanostZanra(int ZanrId);
    }
}
