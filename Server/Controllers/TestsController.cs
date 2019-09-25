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
	public class TestsController : ControllerBase {
		private readonly ServerContext _context;

		public TestsController(ServerContext context) {
			_context = context;
		}

		// GET: api/Tests
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Test>>> GetTest() {
			return await _context.Test.ToListAsync();
		}

		// GET: api/Tests/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Test>> GetTest(long id) {
			var test = await _context.Test.FindAsync(id);

			if (test == null) {
				return NotFound();
			}

			return test;
		}

		// PUT: api/Tests/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutTest(long id, Test test) {
			if (id != test.Id) {
				return BadRequest();
			}

			_context.Entry(test).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException) {
				if (!TestExists(id)) {
					return NotFound();
				}
				else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Tests
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Test>> PostTest(Test test) {
			_context.Test.Add(test);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetTest", new { id = test.Id }, test);
		}

		// DELETE: api/Tests/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Test>> DeleteTest(long id) {
			var test = await _context.Test.FindAsync(id);
			if (test == null) {
				return NotFound();
			}

			_context.Test.Remove(test);
			await _context.SaveChangesAsync();

			return test;
		}

		private bool TestExists(long id) {
			return _context.Test.Any(e => e.Id == id);
		}
	}
}
