using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _5._BlogApp.Models;
using _5._BlogApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _5._BlogApp.Controllers
{
    public class BlogsController : Controller
    {
        private readonly BlogService _blogService;
        private readonly AccountService _accountService;

        public BlogsController(BlogService blogService, AccountService accountService)
        {
            _blogService = blogService;
            _accountService = accountService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _blogService.GetAllBlogs();

            return View(blogs);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<User> users = await _accountService.GetAllUsers();
            ViewBag.Users = users.Select(u => new SelectListItem() { Text = u.PersonName, Value = u.UserID.ToString() });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            await _blogService.CreateBlog(blog);

            return RedirectToAction("Index");
        }

        [Route("singleBlog/{blogId}")]
        public async Task<IActionResult> GetBlogById(Guid blogId)
        {
            Blog blog = await _blogService.GetBlogByID(blogId);

            return View(blog);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid blogID)
        {
            Blog blog = await _blogService.GetBlogByID(blogID);

            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid blogID, Blog updatedBlog)
        {
            await _blogService.Update(blogID, updatedBlog);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid blogID)
        {
            Blog blog = await _blogService.GetBlogByID(blogID);

            return View(blog);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid blogID)
        {
            await _blogService.DeleteBlog(blogID);

            return RedirectToAction("Index");
        }
    }
}

