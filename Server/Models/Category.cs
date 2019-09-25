using System.ComponentModel.DataAnnotations;

namespace WebApp.Models {
	public class Category {
		[Key]
		public long Id { get; set; }

		[StringLength(100)]
		public string Name { get; set; }

		[StringLength(8000)]
		public string Description { get; set; }

		[StringLength(8000)]
		public string Picture { get; set; }
	}
}
