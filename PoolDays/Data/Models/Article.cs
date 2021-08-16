using System;
using System.ComponentModel.DataAnnotations;

namespace PoolDays.Data.Models
{
    using static DataConstants.Article;

    public class Article
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength(ArticleMaxLength, MinimumLength = ArticleMinLength)]
        public string Text { get; set; }

        [Required]
        public string Author { get; set; }
        
        [Required]
        [Url]
        public string ImageURL { get; set; }

        public DateTime DateWritten { get; set; }
    }
}
