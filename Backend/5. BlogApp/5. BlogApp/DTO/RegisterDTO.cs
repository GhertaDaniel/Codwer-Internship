using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace _5._BlogApp.DTO
{
	public class RegisterDTO
	{
		[Required(ErrorMessage = "Numele nu poate camp liber")]
		public string? PersonName { get; set; }

		[Required(ErrorMessage = "Email-ul nu poate camp liber")]
		[EmailAddress(ErrorMessage = "Email-ul trebuie sa fie in formatul corect")]
		[Remote(action: "IsEmailAlreadyRegistered", controller: "Account", ErrorMessage = "Email-ul este deja folosit")]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Parola nu poate fi camp liber")]
		[DataType(DataType.Password)]
		public string? Password { get; set; }

        [Required(ErrorMessage = "Confirma Parola nu poate fi camp liber")]
        [DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Parola si confirma parola nu sunt la fel")]
        public string? ConfirmPassword { get; set; }
    }
}

