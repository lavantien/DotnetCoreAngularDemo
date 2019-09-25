using System.ComponentModel.DataAnnotations;

namespace WebApp.Models {
	public class BalanceRecord {
		[Key]
		public long Id { get; set; }

		[Range(-1000000000.0, 1000000000)]
		public double Balance { get; set; }

		public long TransactionId { get; set; }
	}
}
