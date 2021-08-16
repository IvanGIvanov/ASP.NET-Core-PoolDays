using PoolDays.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Models.Blog
{
    public class BlogViewModel
    {
        public IEnumerable<ArticleModel> Articles { get; set; }
    }
}
