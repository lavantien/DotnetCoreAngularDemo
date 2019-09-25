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
	public class CustomersController : ControllerBase {
		private readonly ServerContext _context;

		public CustomersController(ServerContext context) {
			_context = context;
		}

		// GET: api/Customers
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer() {
			return await _context.Customer.ToListAsync();
		}

		// GET: api/Customers/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Customer>> GetCustomer(long id) {
			var customer = await _context.Customer.FindAsync(id);

			if (customer == null) {
				return NotFound();
			}

			return customer;
		}

		// PUT: api/Customers/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCustomer(long id, Customer customer) {
			if (id != customer.Id) {
				return BadRequest();
			}

			_context.Entry(customer).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException) {
				if (!CustomerExists(id)) {
					return NotFound();
				}
				else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Customers
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Customer>> PostCustomer(Customer customer) {
			_context.Customer.Add(customer);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
		}

		// DELETE: api/Customers/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Customer>> DeleteCustomer(long id) {
			var customer = await _context.Customer.FindAsync(id);
			if (customer == null) {
				return NotFound();
			}

			_context.Customer.Remove(customer);
			await _context.SaveChangesAsync();

			return customer;
		}

		private bool CustomerExists(long id) {
			return _context.Customer.Any(e => e.Id == id);
		}
	}
}
