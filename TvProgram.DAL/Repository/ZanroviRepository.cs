using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvProgram.DAL.Repository.Interfaces;
using TvProgram.Models;
using TvProgram.Models.ViewModels;

namespace TvProgram.DAL.Repository
{
    public class ZanroviRepository : IZanroviRepository
    {
        private readonly DataDbContext _context;

        public ZanroviRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DodajZanr(DodajIliUrediZanrVM model)
        {
            Zanr zanr = new Zanr()
            {
                Naziv = model.Naziv
            };
            await _context.AddAsync(zanr);
            await _context.SaveChangesAsync();
            return true;
        }

        public List<Zanr> DohvatiZanrove(int TvPostajaId)
        {
            List<int> emisijeId = _context.Emisije.Where(e => e.TvPostajaId == TvPostajaId).Select(e => e.ZanrId).ToList();
            return _context.Zanrovi.Where(z => emisijeId.Contains(z.Id)).ToList();
        }

        public List<Zanr> DohvatiSveZanrove()
        {
            return _context.Zanrovi.ToList();
        }


        public async Task<bool> UkloniZanr(int ZanrId)
        {
            Zanr zanr = await _context.Zanrovi.FindAsync(ZanrId);
            _context.Remove(zanr);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UrediZanr(DodajIliUrediZanrVM model, int ZanrId)
        {
            Zanr zanr = await _context.Zanrovi.FindAsync(ZanrId);
            zanr.Naziv = model.Naziv;
            _context.Update(zanr);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool PostojanostZanra(string Naziv)
        {
            return _context.Zanrovi.Any(z => z.Naziv == Naziv);
        }

        public bool PostojanostZanra(int ZanrId)
        {
            return _context.Zanrovi.Any(z => z.Id == ZanrId);
        }

        public Zanr DohvatiZanr(int ZanrId)
        {
            return _context.Zanrovi.Find(ZanrId);
        }
    }
}
