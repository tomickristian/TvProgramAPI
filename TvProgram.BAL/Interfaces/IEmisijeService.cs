using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvProgram.Models;
using TvProgram.Models.ViewModels;

namespace TvProgram.BAL.Interfaces
{
    public interface IEmisijeService
    {
        List<DohvatiEmisijuVM> DohvatiEmisije(int TvPostajaId, int ZanrId);
        DohvatiEmisijuVM DohvatiEmisiju(int EmisijaId);
        Task<bool> DodajEmisiju(DodajIliUrediEmisijuVM model);
        Task<bool> UrediEmisiju(DodajIliUrediEmisijuVM model, int EmisijaId);
        Task<bool> UkloniEmisiju(int EmisijaId);
    }
}
