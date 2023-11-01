using System;
using System.ComponentModel.DataAnnotations;

namespace _5._BlogApp.Models
{
	public class User
	{
		[Key]
		public Guid UserID { get; set; }

		[StringLength(40)]
		public string? PersonName { get; set; }

		[StringLength(40)]
		public string? Email { get; set; }

		public DateTime? DateOfBirth { get; set; }

		public ICollection<Blog> Blogs { get; set; }
	}
}

