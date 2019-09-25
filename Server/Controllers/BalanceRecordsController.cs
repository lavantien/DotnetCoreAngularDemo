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
	public class BalanceRecordsController : ControllerBase {
		private readonly ServerContext _context;

		public BalanceRecordsController(ServerContext context) {
			_context = context;
		}

		// GET: api/BalanceRecords
		[HttpGet]
		public async Task<ActionResult<IEnumerable<BalanceRecord>>> GetBalanceRecord() {
			return await _context.BalanceRecord.ToListAsync();
		}

		// GET: api/BalanceRecords/5
		[HttpGet("{id}")]
		public async Task<ActionResult<BalanceRecord>> GetBalanceRecord(long id) {
			var balanceRecord = await _context.BalanceRecord.FindAsync(id);

			if (balanceRecord == null) {
				return NotFound();
			}

			return balanceRecord;
		}

		// PUT: api/BalanceRecords/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutBalanceRecord(long id, BalanceRecord balanceRecord) {
			if (id != balanceRecord.Id) {
				return BadRequest();
			}

			_context.Entry(balanceRecord).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException) {
				if (!BalanceRecordExists(id)) {
					return NotFound();
				}
				else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/BalanceRecords
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<BalanceRecord>> PostBalanceRecord(BalanceRecord balanceRecord) {
			_context.BalanceRecord.Add(balanceRecord);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetBalanceRecord", new { id = balanceRecord.Id }, balanceRecord);
		}

		// DELETE: api/BalanceRecords/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<BalanceRecord>> DeleteBalanceRecord(long id) {
			var balanceRecord = await _context.BalanceRecord.FindAsync(id);
			if (balanceRecord == null) {
				return NotFound();
			}

			_context.BalanceRecord.Remove(balanceRecord);
			await _context.SaveChangesAsync();

			return balanceRecord;
		}

		private bool BalanceRecordExists(long id) {
			return _context.BalanceRecord.Any(e => e.Id == id);
		}
	}
}
