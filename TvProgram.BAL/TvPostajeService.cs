using System.Collections.Generic;
using System.Threading.Tasks;
using TvProgram.BAL.Interfaces;
using TvProgram.DAL.Repository.Interfaces;
using TvProgram.Models;
using TvProgram.Models.ViewModels;

namespace TvProgram.BAL
{
    public class TvPostajeService : ITvPostajeService
    {
        private readonly ITvPostajeRepository _tvPostajeRepository;

        public TvPostajeService(ITvPostajeRepository context)
        {
            _tvPostajeRepository = context;
        }

        public List<TvPostaja> DohvatiTvPostaje()
        {
            return _tvPostajeRepository.DohvatiTvPostaje();
        }

        public async Task<bool> DodajTvPostaju(DodajIliUrediTvPostajuVM model)
        {
            if (_tvPostajeRepository.PostojanostTvPostaje(model.Naziv)) 
            {
                return false;
            }
            return await _tvPostajeRepository.DodajTvPostaju(model);
        }

        public async Task<bool> UrediTvPostaju(DodajIliUrediTvPostajuVM model, int TvPostajaId)
        {
            if (!_tvPostajeRepository.PostojanostTvPostaje(TvPostajaId)) { return false; }
            return await _tvPostajeRepository.UrediTvPostaju(model, TvPostajaId);
        }

        public async Task<bool> UkloniTvPostaju(int TvPostajaId)
        {
            if (!_tvPostajeRepository.PostojanostTvPostaje(TvPostajaId)) { return false; }
            return await _tvPostajeRepository.UkloniTvPostaju(TvPostajaId);
        }
    }
}
