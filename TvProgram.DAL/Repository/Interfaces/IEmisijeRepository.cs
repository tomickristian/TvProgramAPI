using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvProgram.Models;
using TvProgram.Models.ViewModels;

namespace TvProgram.DAL.Repository.Interfaces
{
    public interface IEmisijeRepository
    {
        List<Emisija> DohvatiEmisije(int TvPostajaId, int ZanrId);
        Emisija DohvatiEmisiju(int EmisijaId);
        Task<bool> DodajEmisiju(DodajIliUrediEmisijuVM model);
        Task<bool> UrediEmisiju(DodajIliUrediEmisijuVM model, int EmisijaId);
        Task<bool> UkloniEmisiju(int EmisijaId);
        bool PostojanostEmisije(string Naziv);
        bool PostojanostEmisije(int EmisijaId);
    }
}
