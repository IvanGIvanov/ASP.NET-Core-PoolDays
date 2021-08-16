using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Models.Blog
{
    public class ArticleModel
    {
        public string Text { get; set; }

        public string Author { get; set; }

        public string ImageURL { get; set; }

        public DateTime DateWritten { get; set; }

        public string Title { get; set; }
    }
}
