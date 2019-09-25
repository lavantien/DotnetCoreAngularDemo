using System.ComponentModel.DataAnnotations;

namespace WebApp.Models {
	public class OrderDetail {
		[Key]
		public long Id { get; set; }

		public long OrderId { get; set; }

		public long ProductId { get; set; }

		[Range(0, 10000000)]
		public long Quantity { get; set; }
	}
}
