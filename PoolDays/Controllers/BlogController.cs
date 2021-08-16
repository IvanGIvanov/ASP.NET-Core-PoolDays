using Microsoft.AspNetCore.Mvc;
using PoolDays.Models.Blog;
using PoolDays.Services.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService articles;

        public BlogController(IBlogService articles) => this.articles = articles;

        public IActionResult Articles()
        {
            var articlesShow = articles.AllArticles();

            return View(articlesShow);
        }
    }
}
