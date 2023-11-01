using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5._BlogApp.Models
{
	public class Blog
	{
		public Guid BlogID { get; set; }
		public string? Title { get; set; }
		public string? Content { get; set; }

		[ForeignKey("User")]
		public Guid? UserID { get; set; }
	}
}

