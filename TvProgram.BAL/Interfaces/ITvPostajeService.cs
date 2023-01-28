using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvProgram.Models;
using TvProgram.Models.ViewModels;

namespace TvProgram.BAL.Interfaces
{
    public interface ITvPostajeService
    {
        List<TvPostaja> DohvatiTvPostaje();
        Task<bool> DodajTvPostaju(DodajIliUrediTvPostajuVM model);
        Task<bool> UrediTvPostaju(DodajIliUrediTvPostajuVM model, int TvPostajaId);
        Task<bool> UkloniTvPostaju(int TvPostajaId);
    }
}
