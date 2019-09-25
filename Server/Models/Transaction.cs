using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models {
	public class Transaction {
		[Key]
		public long Id { get; set; }

		[StringLength(10)]
		public string Action { get; set; }

		[Range(0.0, 1000000000.0)]
		public double Value { get; set; }

		public long ProductId { get; set; }

		[Range(0, 10000000)]
		public long Quantity { get; set; }

		public DateTime Date { get; set; }
	}
}
