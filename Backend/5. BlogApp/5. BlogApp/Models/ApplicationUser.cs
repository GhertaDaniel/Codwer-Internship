using System;
using Microsoft.AspNetCore.Identity;

namespace _5._BlogApp.Models
{
	public class ApplicationUser : IdentityUser
	{	
		[PersonalData]
		public string? PersonName { get; set; }
	}
}

