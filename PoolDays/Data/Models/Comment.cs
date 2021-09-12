using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PoolDays.Data.Models
{
    using static DataConstants.Comment;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Text { get; set; }

        public string UserId { get; set; }

        [Required]
        public int ProductRankting { get; set; }

        public int PoolId { get; set; }

        public IEnumerable<Pool> Pools { get; set; }

        public string UserName { get; set; }
    }
}
