using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Webshop_backend.Db
{
	public class MyDbContext : DbContext
	{
		public DbSet<Proizvod> Proizvodi { get; set; }
		public DbSet<Narudzba> Narudzbe { get; set; }

		public MyDbContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Proizvod>().ToTable("Proizvod");
			modelBuilder.Entity<Proizvod>().HasKey(p => p.IdProizvod);

			modelBuilder.Entity<Narudzba>().ToTable("Narudzba");
			modelBuilder.Entity<Narudzba>().HasKey(n => n.IdNarudzba);
			modelBuilder.Entity<Narudzba>().HasOne(n => n.Klijent).WithMany().HasForeignKey(n => n.IdKlijent);
			modelBuilder.Entity<Narudzba>().HasMany(n => n.Detalji).WithOne().HasForeignKey(d => d.IdNarudzba);

			modelBuilder.Entity<Klijent>().ToTable("Klijent");
			modelBuilder.Entity<Klijent>().HasKey(k => k.IdKlijent);

			modelBuilder.Entity<NarudzbaDetalj>().ToTable("NarudzbaDetalj");
			modelBuilder.Entity<NarudzbaDetalj>().HasKey(n => n.IdNarudzbaDetalj);
		}
	}
}
