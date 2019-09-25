using System.ComponentModel.DataAnnotations;

namespace WebApp.Models {
	public class Customer {
		[Key]
		public long Id { get; set; }

		[StringLength(100)]
		public string Name { get; set; }

		[EmailAddress]
		public string Email { get; set; }

		[Phone]
		public string Phone { get; set; }

		[StringLength(200)]
		public string Address { get; set; }

		public long Level { get; set; }
	}
}
