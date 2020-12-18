﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gameshop_Backend.Db;
using Microsoft.EntityFrameworkCore;

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

		[HttpGet("genres")]
		public List<Genre> GetGenres()
		{
			return context.Genres.ToList();
		}

		[HttpGet("companies")]
		public List<Company> GetCompanies()
		{
			return context.Companies.ToList();
		}

		[HttpGet("bygenre/{id:int}")]
		public List<Game> GetByGenre(int id)
		{
			return context.Games.Where(g => g.IdGenre == id).ToList();
		}
		
		[HttpGet("bycompany/{id:int}")]
		public List<Game> GetByCompany(int id)
		{
			return context.Games.Where(g => g.IdDeveloper == id || g.IdPublisher == id).ToList();
		}

		[HttpGet("search/{text}")]
		public List<Game> Search(string text)
		{
			return context.Games.Include(g => g.Genre).Include(g => g.Publisher)
				.Where(g => g.Title.Contains(text) || g.Genre.Name.Contains(text) || g.Publisher.Name.Contains(text)).ToList();
		}
	}
}
