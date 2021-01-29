using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Webshop_backend.Db;
using Webshop_backend.JWT;

namespace Webshop_backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly MyDbContext context;
		private readonly IJwtAuthManager jwtAuthManager;

		public UserController(MyDbContext context, IJwtAuthManager jwtAuthManager)
		{
			this.context = context;
			this.jwtAuthManager = jwtAuthManager;
		}

		[HttpGet("login")]
		public LoginResult Login(string login, string password)
		{
			var zaposlenik = context.Zaposlenici.FirstOrDefault(z => z.Login == login && z.Password == password);
			if(zaposlenik != null)
			{
				var claims = new[]
				{
					new Claim(ClaimTypes.GivenName, login)
				};
				var jwtResult = jwtAuthManager.GenerateTokens(login, claims, DateTime.Now);
				var loginResult = new LoginResult
				{
					Zaposlenik = zaposlenik,
					AccessToken = jwtResult.AccessToken,
					RefreshToken = jwtResult.RefreshToken.TokenString
				};
				return loginResult;
			}
			return null;
		}


	}

	public class LoginResult
	{
		public Zaposlenik Zaposlenik { get; set; }
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
	}
}
