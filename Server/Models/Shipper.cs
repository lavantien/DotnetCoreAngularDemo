using System.ComponentModel.DataAnnotations;

namespace WebApp.Models {
	public class Shipper {
		[Key]
		public long Id { get; set; }

		[StringLength(100)]
		public string Name { get; set; }

		[Phone]
		public string Phone { get; set; }
	}
}
