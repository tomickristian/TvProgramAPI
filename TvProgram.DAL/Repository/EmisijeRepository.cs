using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvProgram.DAL.Repository.Interfaces;
using TvProgram.Models;
using TvProgram.Models.ViewModels;

namespace TvProgram.DAL.Repository
{
    public class EmisijeRepository : IEmisijeRepository
    {
        private readonly DataDbContext _context;

        public EmisijeRepository(DataDbContext context)
        {
            _context = context;
        }

        public List<Emisija> DohvatiEmisije(int TvPostajaId, int ZanrId)
        {
            if (ZanrId == 0)
            {
                return _context.Emisije.Where(e => e.TvPostajaId == TvPostajaId).ToList();
            }
            return _context.Emisije.Where(e => e.TvPostajaId == TvPostajaId && e.ZanrId == ZanrId).ToList();
        }

        public Emisija DohvatiEmisiju(int EmisijaId)
        {
            return _context.Emisije.First(e => e.Id == EmisijaId);
        }

        public async Task<bool> DodajEmisiju(DodajIliUrediEmisijuVM model)
        {
            Emisija emisija = new Emisija()
            {
                Naziv = model.Naziv,
                Opis = model.Opis,
                ZanrId = model.ZanrId,
                TvPostajaId = model.TvPostajaId,
                DatumIVrijemePrikazivanja = DateTime.Now
            };
            await _context.AddAsync(emisija);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UkloniEmisiju(int EmisijaId)
        {
            Emisija emisija = await _context.Emisije.FindAsync(EmisijaId);
            _context.Remove(emisija);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UrediEmisiju(DodajIliUrediEmisijuVM model, int EmisijaId)
        {
            Emisija emisija = await _context.Emisije.FindAsync(EmisijaId);
            emisija.Naziv = model.Naziv;
            emisija.Opis = model.Opis;
            emisija.TvPostajaId = model.TvPostajaId;
            emisija.ZanrId = model.ZanrId;
            emisija.DatumIVrijemePrikazivanja = DateTime.Now;
            _context.Update(emisija);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool PostojanostEmisije(string Naziv)
        {
            return _context.Emisije.Any(e => e.Naziv == Naziv);
        }

        public bool PostojanostEmisije(int EmisijaId)
        {
            return _context.Emisije.Any(e => e.Id == EmisijaId);
        }
    }
}
