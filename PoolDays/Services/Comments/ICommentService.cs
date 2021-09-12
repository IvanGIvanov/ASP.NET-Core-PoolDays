using PoolDays.Services.Comments.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services.Comments
{
    public interface ICommentService
    {
        public int Create(string text, int productRankting, int poolId, string userId);

        public IEnumerable<CommentShowModel> ShowPoolComment(int employeeId);
    }
}
