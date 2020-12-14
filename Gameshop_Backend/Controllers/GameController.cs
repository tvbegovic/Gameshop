using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gameshop_Backend.Db;

namespace Gameshop_Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GameController : ControllerBase
	{
		private readonly MyDbContext context;

		public GameController(MyDbContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public List<Genre> GetGenres()
		{
			return context.Genres.ToList();
		}
	}
}
