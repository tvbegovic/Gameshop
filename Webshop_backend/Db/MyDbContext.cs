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

		public MyDbContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Proizvod>().ToTable("Proizvod");
			modelBuilder.Entity<Proizvod>().HasKey(p => p.IdProizvod);
		}
	}
}
