using System;
using System.ComponentModel.DataAnnotations;

namespace _5._BlogApp.DTO
{
	public class LoginDTO
	{
		[Required(ErrorMessage = "Email-ul nu poate fi camp gol")]
		[EmailAddress(ErrorMessage = "Email trebuie sa fie in format corect")]
		[DataType(DataType.EmailAddress)]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Parola nu poate fi camp gol")]
		[DataType(DataType.Password)]
		public string? Password { get; set; }
	}
}

