using PoolDays.Services.Pools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Models.Comments
{
    using static Data.DataConstants.Comment;

    public class CommentFormModel
    {
        [Required]
        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Text { get; set; }

        [Required]
        [Range(1, 5)]
        public int ProductRankting { get; set; }

        public int PoolId { get; set; }

        public int JacuzziId { get; set; }
    }
}
