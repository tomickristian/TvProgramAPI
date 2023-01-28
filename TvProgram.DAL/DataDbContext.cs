using Microsoft.EntityFrameworkCore;
using System;
using TvProgram.Models;

namespace TvProgram.DAL
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options)
            : base(options)
        {
        }
        public DbSet<TvPostaja> TvPostaje { get; set; }
        public DbSet<Emisija> Emisije { get; set; }
        public DbSet<Zanr> Zanrovi { get; set; }
    }
}
