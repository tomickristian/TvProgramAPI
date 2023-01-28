using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvProgram.DAL.Repository.Interfaces;
using TvProgram.Models;
using TvProgram.Models.ViewModels;

namespace TvProgram.DAL.Repository
{
    public class TvPostajeRepository : ITvPostajeRepository
    {
        private readonly DataDbContext _context;

        public TvPostajeRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DodajTvPostaju(DodajIliUrediTvPostajuVM model)
        {
            TvPostaja postaja = new TvPostaja()
            {
                Naziv = model.Naziv
            };
            await _context.AddAsync(postaja);
            await _context.SaveChangesAsync();
            return true;
        }

        public List<TvPostaja> DohvatiTvPostaje()
        {
            return _context.TvPostaje.ToList();
        }

        public TvPostaja DohvatiTvPostaju(int TvPostajaId)
        {
            return  _context.TvPostaje.Find(TvPostajaId);
        }

        public async Task<bool> UkloniTvPostaju(int TvPostajaId)
        {
            TvPostaja postaja = await _context.TvPostaje.FindAsync(TvPostajaId);
            _context.Remove(postaja);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UrediTvPostaju(DodajIliUrediTvPostajuVM model, int TvPostajaId)
        {
            TvPostaja postaja = await _context.TvPostaje.FindAsync(TvPostajaId);
            postaja.Naziv = model.Naziv;
            _context.Update(postaja);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool PostojanostTvPostaje(string Naziv)
        {
            return _context.TvPostaje.Any(t => t.Naziv == Naziv);
        }

        public bool PostojanostTvPostaje(int TvPostajeId)
        {
            return _context.TvPostaje.Any(t => t.Id == TvPostajeId);
        }
    }
}
