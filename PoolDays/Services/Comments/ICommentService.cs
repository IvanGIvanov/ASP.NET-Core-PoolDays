using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services.Comments
{
    public interface ICommentService
    {
        public int Create(string text, int productRankting, int poolId, int jacuzziId, string userId);
    }
}
