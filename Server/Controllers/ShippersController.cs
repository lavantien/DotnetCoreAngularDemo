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
	public class ShippersController : ControllerBase {
		private readonly ServerContext _context;

		public ShippersController(ServerContext context) {
			_context = context;
		}

		// GET: api/Shippers
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Shipper>>> GetShipper() {
			return await _context.Shipper.ToListAsync();
		}

		// GET: api/Shippers/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Shipper>> GetShipper(long id) {
			var shipper = await _context.Shipper.FindAsync(id);

			if (shipper == null) {
				return NotFound();
			}

			return shipper;
		}

		// PUT: api/Shippers/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutShipper(long id, Shipper shipper) {
			if (id != shipper.Id) {
				return BadRequest();
			}

			_context.Entry(shipper).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException) {
				if (!ShipperExists(id)) {
					return NotFound();
				}
				else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Shippers
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Shipper>> PostShipper(Shipper shipper) {
			_context.Shipper.Add(shipper);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetShipper", new { id = shipper.Id }, shipper);
		}

		// DELETE: api/Shippers/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Shipper>> DeleteShipper(long id) {
			var shipper = await _context.Shipper.FindAsync(id);
			if (shipper == null) {
				return NotFound();
			}

			_context.Shipper.Remove(shipper);
			await _context.SaveChangesAsync();

			return shipper;
		}

		private bool ShipperExists(long id) {
			return _context.Shipper.Any(e => e.Id == id);
		}
	}
}
