using AutoMapper;
using AutoMapper.QueryableExtensions;
using PoolDays.Data;
using PoolDays.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services.Blog
{
    public class BlogService : IBlogService
    {
        private readonly PoolDaysDBContext data;
        private readonly IMapper mapper;

        public BlogService(PoolDaysDBContext data, IMapper mapper) 
        {
            this.data = data;
            this.mapper = mapper;
        }

        public BlogViewModel AllArticles()
        {
            var articles = data
                .Articles
                .ProjectTo<ArticleModel>(this.mapper.ConfigurationProvider)
                .ToList();

            var retArt = new BlogViewModel
            {
                Articles = articles
            };

            return retArt;
        }
    }
}
