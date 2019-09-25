using System.ComponentModel.DataAnnotations;

namespace WebApp.Models {
	public class Product {
		[Key]
		public long Id { get; set; }

		[StringLength(100)]
		public string Name { get; set; }

		[Range(0.0, 1000000.0)]
		public double Price { get; set; }

		[StringLength(8000)]
		public string Description { get; set; }

		[StringLength(8000)]
		public string Picture { get; set; }

		public long CategoryId { get; set; }
	}
}
