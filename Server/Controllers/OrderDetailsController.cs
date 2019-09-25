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
	public class OrderDetailsController : ControllerBase {
		private readonly ServerContext _context;

		public OrderDetailsController(ServerContext context) {
			_context = context;
		}

		// GET: api/OrderDetails
		[HttpGet]
		public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetail() {
			return await _context.OrderDetail.ToListAsync();
		}

		// GET: api/OrderDetails/5
		[HttpGet("{id}")]
		public async Task<ActionResult<OrderDetail>> GetOrderDetail(long id) {
			var orderDetail = await _context.OrderDetail.FindAsync(id);

			if (orderDetail == null) {
				return NotFound();
			}

			return orderDetail;
		}

		// PUT: api/OrderDetails/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutOrderDetail(long id, OrderDetail orderDetail) {
			if (id != orderDetail.Id) {
				return BadRequest();
			}

			_context.Entry(orderDetail).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException) {
				if (!OrderDetailExists(id)) {
					return NotFound();
				}
				else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/OrderDetails
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetail orderDetail) {
			_context.OrderDetail.Add(orderDetail);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetOrderDetail", new { id = orderDetail.Id }, orderDetail);
		}

		// DELETE: api/OrderDetails/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<OrderDetail>> DeleteOrderDetail(long id) {
			var orderDetail = await _context.OrderDetail.FindAsync(id);
			if (orderDetail == null) {
				return NotFound();
			}

			_context.OrderDetail.Remove(orderDetail);
			await _context.SaveChangesAsync();

			return orderDetail;
		}

		private bool OrderDetailExists(long id) {
			return _context.OrderDetail.Any(e => e.Id == id);
		}
	}
}
