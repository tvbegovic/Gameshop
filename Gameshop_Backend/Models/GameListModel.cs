using Gameshop_Backend.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gameshop_Backend.Models
{
	public class GameListModel
	{
		public List<Genre> Genres { get; set; }
		public List<Company> Companies { get; set; }
		public List<Game> Games { get; set; }
	}
}
