using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gameshop_Backend.Db;
using Microsoft.EntityFrameworkCore;
using Gameshop_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Gameshop_Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]	
	public class GameController : ControllerBase
	{
		private readonly MyDbContext context;
		private readonly IWebHostEnvironment webHostEnvironment;

		public GameController(MyDbContext context, IWebHostEnvironment webHostEnvironment)
		{
			this.context = context;
			this.webHostEnvironment = webHostEnvironment;
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

		[HttpGet("listModel")]
		[Authorize]
		public GameListModel GetListModel()
		{
			return new GameListModel
			{
				Companies = context.Companies.ToList(),
				Genres = context.Genres.ToList(),
				Games = context.Games.ToList()
			};
		}

		[HttpPost("")]
		[Authorize]
		public Game Create(Game game)
		{
			HandleFile(game);
			context.Games.Add(game);
			context.SaveChanges();
			return game;
		}

		[HttpPut("")]
		[Authorize]
		public Game Update(Game game)
		{
			HandleFile(game);
			context.Games.Update(game);
			context.SaveChanges();
			return game;
		}

		[HttpDelete("{id}")]
		[Authorize]
		public void Delete(int id)
		{
			context.Database.ExecuteSqlInterpolated($"DELETE FROM Game WHERE id = {id}");
		}

		[HttpGet("editModel/{id}")]
		[Authorize]
		public GameEditModel GetEditModel(int id)
		{
			return new GameEditModel
			{
				Companies = context.Companies.ToList(),
				Game = id > 0 ? context.Games.FirstOrDefault(g => g.Id == id) : new Game(),
				Genres = context.Genres.ToList()
			};
		}

		[HttpPost("uploadImage")]
		[Authorize]
		public void UploadImage(string id)
		{
			var file = Request.Form.Files[0];
			if(file.Length > 0)
			{
				var filePath = Path.Combine(webHostEnvironment.WebRootPath, "assets\\tmpImages", $"{id}.jpg");
				var sw = new StreamWriter(filePath);
				file.CopyTo(sw.BaseStream);
				sw.Close();

			}
		}

		private void HandleFile(Game game)
		{
			if(!string.IsNullOrEmpty(game.FileId))
			{
				var tmpFilePath = Path.Combine(webHostEnvironment.WebRootPath, "assets\\tmpImages", $"{game.FileId}.jpg");
				if(System.IO.File.Exists(tmpFilePath))
				{
					var finalFilePath = Path.Combine(webHostEnvironment.WebRootPath, "assets\\gameImages", $"{game.FileId}.jpg");
					System.IO.File.Copy(tmpFilePath, finalFilePath);
					game.image = $"{game.FileId}.jpg";
					System.IO.File.Delete(tmpFilePath);
				}
			}
		}
	}
}
