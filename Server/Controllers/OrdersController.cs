using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace Server.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase {
		private readonly ServerContext _context;

		public OrdersController(ServerContext context) {
			_context = context;
		}

		// GET: api/Orders
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Order>>> GetOrder() {
			return await _context.Order.ToListAsync();
		}

		// GET: api/Orders/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Order>> GetOrder(long id) {
			var order = await _context.Order.FindAsync(id);

			if (order == null) {
				return NotFound();
			}

			return order;
		}

		// PUT: api/Orders/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutOrder(long id, Order order) {
			if (id != order.Id) {
				return BadRequest();
			}

			_context.Entry(order).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException) {
				if (!OrderExists(id)) {
					return NotFound();
				}
				else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Orders
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Order>> PostOrder(Order order) {
			_context.Order.Add(order);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetOrder", new { id = order.Id }, order);
		}

		// DELETE: api/Orders/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Order>> DeleteOrder(long id) {
			var order = await _context.Order.FindAsync(id);
			if (order == null) {
				return NotFound();
			}

			_context.Order.Remove(order);
			await _context.SaveChangesAsync();

			return order;
		}

		private bool OrderExists(long id) {
			return _context.Order.Any(e => e.Id == id);
		}
	}
}
