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
	public class TransactionsController : ControllerBase {
		private readonly ServerContext _context;

		public TransactionsController(ServerContext context) {
			_context = context;
		}

		// GET: api/Transactions
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Transaction>>> GetTransaction() {
			return await _context.Transaction.ToListAsync();
		}

		// GET: api/Transactions/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Transaction>> GetTransaction(long id) {
			var transaction = await _context.Transaction.FindAsync(id);

			if (transaction == null) {
				return NotFound();
			}

			return transaction;
		}

		// PUT: api/Transactions/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutTransaction(long id, Transaction transaction) {
			if (id != transaction.Id) {
				return BadRequest();
			}

			_context.Entry(transaction).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException) {
				if (!TransactionExists(id)) {
					return NotFound();
				}
				else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Transactions
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction) {
			_context.Transaction.Add(transaction);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetTransaction", new { id = transaction.Id }, transaction);
		}

		// DELETE: api/Transactions/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Transaction>> DeleteTransaction(long id) {
			var transaction = await _context.Transaction.FindAsync(id);
			if (transaction == null) {
				return NotFound();
			}

			_context.Transaction.Remove(transaction);
			await _context.SaveChangesAsync();

			return transaction;
		}

		private bool TransactionExists(long id) {
			return _context.Transaction.Any(e => e.Id == id);
		}
	}
}
