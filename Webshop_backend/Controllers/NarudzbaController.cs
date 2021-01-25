using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop_backend.Db;
using Microsoft.EntityFrameworkCore;

namespace Webshop_backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NarudzbaController : ControllerBase
	{
		private readonly MyDbContext context;

		public NarudzbaController(MyDbContext context)
		{
			this.context = context;
		}

		//api/narudzba/30000
		[HttpGet("{id}")]
		public Narudzba GetById(int id)
		{
			return context.Narudzbe.Include(n => n.Klijent).Include(n => n.Detalji).FirstOrDefault(n => n.IdNarudzba == id);
		}
	}
}
