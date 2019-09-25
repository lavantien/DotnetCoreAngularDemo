using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models {
	public class Test {
		[Key]
		public long Id { get; set; }

		[StringLength(100)]
		public string Name { get; set; }

		[Range(0.0, 10000000.0)]
		public double Value { get; set; }

		public DateTime Date { get; set; }

		[StringLength(8000)]
		public string Image { get; set; }
		
		public long OsId { get; set; }
	}
}
