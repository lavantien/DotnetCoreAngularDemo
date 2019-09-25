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
	public class ManagersController : ControllerBase {
		private readonly ServerContext _context;

		public ManagersController(ServerContext context) {
			_context = context;
		}

		// GET: api/Managers
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Manager>>> GetManager() {
			return await _context.Manager.ToListAsync();
		}

		// GET: api/Managers/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Manager>> GetManager(long id) {
			var manager = await _context.Manager.FindAsync(id);

			if (manager == null) {
				return NotFound();
			}

			return manager;
		}

		// PUT: api/Managers/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutManager(long id, Manager manager) {
			if (id != manager.Id) {
				return BadRequest();
			}

			_context.Entry(manager).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException) {
				if (!ManagerExists(id)) {
					return NotFound();
				}
				else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Managers
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Manager>> PostManager(Manager manager) {
			_context.Manager.Add(manager);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetManager", new { id = manager.Id }, manager);
		}

		// DELETE: api/Managers/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Manager>> DeleteManager(long id) {
			var manager = await _context.Manager.FindAsync(id);
			if (manager == null) {
				return NotFound();
			}

			_context.Manager.Remove(manager);
			await _context.SaveChangesAsync();

			return manager;
		}

		private bool ManagerExists(long id) {
			return _context.Manager.Any(e => e.Id == id);
		}
	}
}
