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
            var username = data
                .Users
                .FirstOrDefault(u => u.Id == userId);

            var commentData = new Comment
            {
                Text = text,
                ProductRankting = productRankting,
                PoolId = poolId,
                JacuzziId = jacuzziId,
                UserId = userId,
                UserName = username.FirstName
            };

            this.data.Comments.Add(commentData);
            this.data.SaveChanges();

            return commentData.Id;
        }

        public IEnumerable<CommentShowModel> ShowPoolComment(int productId)
        {
            var commentsToShow = this.data
                .Comments
                .Where(c => c.PoolId == productId)
                .Select(c => new CommentShowModel
                {
                    Id = c.Id,
                    Text = c.Text,
                    Rating = c.ProductRankting,
                    UserName = c.UserName,
                    
                })
                .ToList();

            return commentsToShow;
        }

        public IEnumerable<CommentShowModel> ShowJacuzziComment(int productId)
        {
            var commentsToShow = this.data
                .Comments
                .Where(c => c.JacuzziId == productId)
                .Select(c => new CommentShowModel
                {
                    Id = c.Id,
                    Text = c.Text,
                    Rating = c.ProductRankting,
                    UserName = c.UserName,

                })
                .ToList();

            return commentsToShow;
        }
    }
}
