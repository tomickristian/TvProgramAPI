using System.Collections.Generic;
using System.Threading.Tasks;
using TvProgram.BAL.Interfaces;
using TvProgram.DAL.Repository.Interfaces;
using TvProgram.Models;
using TvProgram.Models.ViewModels;

namespace TvProgram.BAL
{
    public class ZanroviService : IZanroviService
    {
        private readonly IZanroviRepository _zanroviRepository;
        private readonly ITvPostajeRepository _tvPostajeRepository;

        public ZanroviService(IZanroviRepository zanroviRepository, ITvPostajeRepository tvPostajeRepository)
        {
            _zanroviRepository = zanroviRepository;
            _tvPostajeRepository = tvPostajeRepository;
        }
        public List<Zanr> DohvatiZanrove(int TvPostajaId)
        {
            if (!_tvPostajeRepository.PostojanostTvPostaje(TvPostajaId))
            {
                return _zanroviRepository.DohvatiSveZanrove();
            }
            return _zanroviRepository.DohvatiZanrove(TvPostajaId);
        }

        public async Task<bool> DodajZanr(DodajIliUrediZanrVM model)
        {
            if (_zanroviRepository.PostojanostZanra(model.Naziv)) { return false; }
            
            return await _zanroviRepository.DodajZanr(model);
        }

        public async Task<bool> UrediZanr(DodajIliUrediZanrVM model, int ZanrId)
        {
            if (!_zanroviRepository.PostojanostZanra(ZanrId)) { return false; }
            return await _zanroviRepository.UrediZanr(model, ZanrId);
        }

        public async Task<bool> UkloniZanr(int ZanrId)
        {
            if (!_zanroviRepository.PostojanostZanra(ZanrId)) { return false; }
            return await _zanroviRepository.UkloniZanr(ZanrId);
        }
    }
}
