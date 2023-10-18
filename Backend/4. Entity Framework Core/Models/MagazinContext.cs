using System;
using Microsoft.EntityFrameworkCore;

namespace _4._Entity_Framework_Core
{
	public class MagazinContext : DbContext
	{
		public DbSet<Persoana> Persoane { get; set; }
		public DbSet<Comanda> Comenzi { get; set; }
		public DbSet<Produs> Produse { get; set; }
		public DbSet<ComandaProdus> ComenziProduse { get; set; }

		public MagazinContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			//base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Server=localhost,1433;database=Magazin;user=SA;password=4566.LDlimba0;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<ComandaProdus>().HasKey(cp => new { cp.ComandaID, cp.ProdusID });
		}
    }
}

