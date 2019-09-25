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
	public class ProductsController : ControllerBase {
		private readonly ServerContext _context;

		public ProductsController(ServerContext context) {
			_context = context;
		}

		// GET: api/Products
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetProduct() {
			return await _context.Product.ToListAsync();
		}

		// GET: api/Products/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProduct(long id) {
			var product = await _context.Product.FindAsync(id);

			if (product == null) {
				return NotFound();
			}

			return product;
		}

		// PUT: api/Products/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutProduct(long id, Product product) {
			if (id != product.Id) {
				return BadRequest();
			}

			_context.Entry(product).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException) {
				if (!ProductExists(id)) {
					return NotFound();
				}
				else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Products
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Product>> PostProduct(Product product) {
			_context.Product.Add(product);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetProduct", new { id = product.Id }, product);
		}

		// DELETE: api/Products/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Product>> DeleteProduct(long id) {
			var product = await _context.Product.FindAsync(id);
			if (product == null) {
				return NotFound();
			}

			_context.Product.Remove(product);
			await _context.SaveChangesAsync();

			return product;
		}

		private bool ProductExists(long id) {
			return _context.Product.Any(e => e.Id == id);
		}
	}
}
