using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace Server.Models {
	public class ServerContext : DbContext {
		public ServerContext(DbContextOptions<ServerContext> options)
			: base(options) {
		}

		public DbSet<BalanceRecord> BalanceRecord { get; set; }

		public DbSet<Category> Category { get; set; }

		public DbSet<Customer> Customer { get; set; }

		public DbSet<Manager> Manager { get; set; }

		public DbSet<Order> Order { get; set; }

		public DbSet<OrderDetail> OrderDetail { get; set; }

		public DbSet<Product> Product { get; set; }

		public DbSet<Shipper> Shipper { get; set; }

		public DbSet<Test> Test { get; set; }

		public DbSet<Transaction> Transaction { get; set; }
	}
}
