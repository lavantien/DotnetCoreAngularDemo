using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models {
	public class Manager {
		[Key]
		public long Id { get; set; }

		[StringLength(100)]
		public string Name { get; set; }

		[EmailAddress]
		public string Email { get; set; }

		[Phone]
		public string Phone { get; set; }

		[StringLength(50)]
		public string Username { get; set; }

		[StringLength(50)]
		public string Password { get; set; }

		public DateTime JoinDate { get; set; }

		public bool IsRoot { get; set; }
	}
}
