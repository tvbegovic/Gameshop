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
	public class OrderController : ControllerBase
	{
		private readonly MyDbContext context;

		public OrderController(MyDbContext context)
		{
			this.context = context;
		}

		[HttpPost("")]
		public Order Create(Order order)
		{
			if(order.DateOrdered == null)
			{
				order.DateOrdered = DateTime.Now;
			}
			context.Orders.Add(order);
			context.SaveChanges();
			return order;
		}
	}
}
