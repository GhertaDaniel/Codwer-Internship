using System;
using _5._BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace _5._BlogApp.Services
{
	public class BlogService
	{
		private readonly ApplicationDbContext _db;

		public BlogService(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<List<Blog>> GetAllBlogs()
		{
			return await _db.Blogs.ToListAsync();
		}

		public async Task<bool> CreateBlog(Blog blog)
		{
			//User user = await _accountService.GetProfile(blog.BlogID);
			User user = await _db.Users.FirstOrDefaultAsync(u => u.UserID == blog.UserID);
			Blog blogToAdd = new Blog()
			{
				BlogID = blog.BlogID,
				Content = blog.Content,
				Title = blog.Title,
				UserID = user.UserID,
			};

			_db.Blogs.Add(blogToAdd);
			await _db.SaveChangesAsync();
			return true;
		}

        public async Task<Blog> GetBlogByID(Guid blogID)
		{
			return await _db.Blogs.FirstOrDefaultAsync(blog => blog.BlogID == blogID);
		}

		public async Task<Blog> Update(Guid blogId, Blog blog)
		{
			Blog existingBlog = await _db.Blogs.FirstOrDefaultAsync(blog => blog.BlogID == blogId);

			existingBlog.Title = blog.Title;
            existingBlog.Content = blog.Content;

            _db.Blogs.Update(existingBlog);
			await _db.SaveChangesAsync();

			return blog;
		}

		public async Task<bool> DeleteBlog(Guid blogId)
		{
			var blog = await _db.Blogs.FirstOrDefaultAsync(blog => blog.BlogID == blogId);
			_db.Blogs.Remove(blog);
			await _db.SaveChangesAsync();

			return true;
		}
 	}
}

