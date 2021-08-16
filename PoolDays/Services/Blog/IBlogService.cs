using PoolDays.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services.Blog
{
    public interface IBlogService
    {
        public BlogViewModel AllArticles();
    }
}
