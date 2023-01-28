using System.Collections.Generic;
using System.Threading.Tasks;
using TvProgram.BAL.Interfaces;
using TvProgram.DAL.Repository.Interfaces;
using TvProgram.Models;
using TvProgram.Models.ViewModels;

namespace TvProgram.BAL
{
    public class EmisijeService : IEmisijeService
    {
        private readonly IEmisijeRepository _emisijeRepository;
        private readonly ITvPostajeRepository _tvPostajeRepository;
        private readonly IZanroviRepository _zanrRepository;

        public EmisijeService(IEmisijeRepository emisijeRepository, ITvPostajeRepository tvPostajeRepository, IZanroviRepository zanrRepository)
        {
            _emisijeRepository = emisijeRepository;
            _tvPostajeRepository = tvPostajeRepository;
            _zanrRepository = zanrRepository;
        }

        public List<DohvatiEmisijuVM> DohvatiEmisije(int TvPostajaId, int ZanrId)
        {
            if (!_tvPostajeRepository.PostojanostTvPostaje(TvPostajaId) && !_zanrRepository.PostojanostZanra(ZanrId)) { return null; }
            List<Emisija> emisije = _emisijeRepository.DohvatiEmisije(TvPostajaId, ZanrId);
            List<DohvatiEmisijuVM> emisijeVM = new List<DohvatiEmisijuVM>();
            foreach (Emisija e in emisije)
            {
                emisijeVM.Add(EmisijaUDohvatiEmisijuVM(e));
            }
            return emisijeVM;
        }

        public DohvatiEmisijuVM DohvatiEmisiju(int EmisijaId)
        {
            return EmisijaUDohvatiEmisijuVM(_emisijeRepository.DohvatiEmisiju(EmisijaId));
        }

        public async Task<bool> DodajEmisiju(DodajIliUrediEmisijuVM model)
        {
            if (_emisijeRepository.PostojanostEmisije(model.Naziv) 
                && !_tvPostajeRepository.PostojanostTvPostaje(model.TvPostajaId)
                && !_zanrRepository.PostojanostZanra(model.ZanrId))
            { return false; }
            return await _emisijeRepository.DodajEmisiju(model);
        }

        public async Task<bool> UrediEmisiju(DodajIliUrediEmisijuVM model, int EmisijaId)
        {
            if (!_emisijeRepository.PostojanostEmisije(EmisijaId)
                && !_tvPostajeRepository.PostojanostTvPostaje(model.TvPostajaId)
                && !_zanrRepository.PostojanostZanra(model.ZanrId))
            { return false; }
            return await _emisijeRepository.UrediEmisiju(model, EmisijaId);
        }

        public async Task<bool> UkloniEmisiju(int EmisijaId)
        {
            if (!_emisijeRepository.PostojanostEmisije(EmisijaId)) { return false; }
            return await _emisijeRepository.UkloniEmisiju(EmisijaId);
        }

        private DohvatiEmisijuVM EmisijaUDohvatiEmisijuVM(Emisija e)
        {
            return new DohvatiEmisijuVM
            {
                Id = e.Id,
                Naziv = e.Naziv,
                Opis = e.Opis,
                DatumIVrijemePrikazivanja = e.DatumIVrijemePrikazivanja,
                TvPostaja = _tvPostajeRepository.DohvatiTvPostaju(e.TvPostajaId).Naziv,
                Zanr = _zanrRepository.DohvatiZanr(e.ZanrId).Naziv
            };
        }
    }
}
