using AutoMapper;
using PoolDays.Data.Models;
using PoolDays.Models.Blog;
using PoolDays.Models.Home;
using PoolDays.Models.Pools;
using PoolDays.Services.Comments.Model;
using PoolDays.Services.Pools;

namespace PoolDays.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<PoolServiceModel, PoolFormModel>();
            this.CreateMap<Pool, PoolIndexViewModel>();
            this.CreateMap<Pool, PoolServiceModel>();

            this.CreateMap<Comment, CommentShowModel>();

            this.CreateMap<Article, ArticleModel>();
        }
    }
}
