using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using PoolDays.Data;
using PoolDays.Data.Models;
using PoolDays.Services.Comments.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly PoolDaysDBContext data;
        private readonly IMapper mapper;

        public CommentService(PoolDaysDBContext data, IMapper mapper) 
        {
            this.data = data;
            this.mapper = mapper;
        }

        public int Create(string text, int productRankting, int poolId, int jacuzziId, string userId) 
        { 
            var commentData = new Comment
            {
                Text = text,
                ProductRankting = productRankting,
                PoolId = poolId,
                JacuzziId = jacuzziId,
                UserId = userId
            };

            this.data.Comments.Add(commentData);
            this.data.SaveChanges();

            return commentData.Id;
        }

        public IEnumerable<CommentShowModel> ShowComment(string employeeId)
        {
            var commentsToShow = this.data
                .Comments
                .Where(c => c.UserId == employeeId)
                .ProjectTo<CommentShowModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return commentsToShow;
        }
    }
}
