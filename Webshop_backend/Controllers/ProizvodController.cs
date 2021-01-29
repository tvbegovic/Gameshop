using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop_backend.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Webshop_backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProizvodController : ControllerBase
	{
		private readonly MyDbContext context;

		public ProizvodController(MyDbContext context)
		{
			this.context = context;
		}

		//Javlja se na api/proizvod
		[HttpGet("")]
		[Authorize]
		public List<Proizvod> GetProizvodi()
		{
			return context.Proizvodi.ToList();
		}

		//api/proizvod/search?cijenaOd=100&cijenaDo=500&text=AR
		[HttpGet("search")]
		public List<Proizvod> Search(decimal? cijenaOd = null, decimal? cijenaDo = null, string text = null)
		{
			return context.Proizvodi.Where(p =>
				(p.ProdajnaCijena >= cijenaOd || cijenaOd == null) &&
				(p.ProdajnaCijena <= cijenaDo || cijenaDo == null) &&
				(p.Naziv.Contains(text) || p.Broj.Contains(text) || text == null)
				).ToList();
		}

		[HttpPost("")]
		public Proizvod Create(Proizvod proizvod)
		{
			context.Proizvodi.Add(proizvod);
			context.SaveChanges();
			return proizvod;
		}

		[HttpPut("")]
		public Proizvod Update(Proizvod proizvod)
		{
			context.Proizvodi.Update(proizvod);
			context.SaveChanges();
			return proizvod;
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			context.Database.ExecuteSqlInterpolated($"DELETE FROM Proizvod WHERE idProizvod = {id}");
		}


	}
}
