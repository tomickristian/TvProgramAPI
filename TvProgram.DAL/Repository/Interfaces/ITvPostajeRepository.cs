using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvProgram.Models;
using TvProgram.Models.ViewModels;

namespace TvProgram.DAL.Repository.Interfaces
{
    public interface ITvPostajeRepository
    {
        List<TvPostaja> DohvatiTvPostaje();
        TvPostaja DohvatiTvPostaju(int TvPostajaId);
        Task<bool> DodajTvPostaju(DodajIliUrediTvPostajuVM model);
        Task<bool> UrediTvPostaju(DodajIliUrediTvPostajuVM model, int TvPostajaId);
        Task<bool> UkloniTvPostaju(int TvPostajaId);
        bool PostojanostTvPostaje(string Naziv);
        bool PostojanostTvPostaje(int TvPostajeId);
    }
}
