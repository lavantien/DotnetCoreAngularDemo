using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models {
	public class Order {
		[Key]
		public long Id { get; set; }

		public long CustomerId { get; set; }

		public long ShipperId { get; set; }

		public DateTime Date { get; set; }

		[StringLength(10)]
		public string Status { get; set; }
	}
}
