using System;
using _5._BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace _5._BlogApp.Services
{
	public class AccountService
	{
		private readonly ApplicationDbContext _db;

		public AccountService(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<User> GetProfile(Guid id)
		{
			User? user = await _db.Users.FirstOrDefaultAsync(user => user.UserID == id);

			if (user == null) return null;

			return user;
		}

		public async Task<List<User>> GetAllUsers()
		{
			return await _db.Users.ToListAsync();
		}
	}
}

