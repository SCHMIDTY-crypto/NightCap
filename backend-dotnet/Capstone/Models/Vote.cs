using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Vote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoteId { get; set; }

        [ForeignKey("users")]
        public int UserId { get; set; }

        [ForeignKey("Post")]
        public int? PostId { get; set; }

        [ForeignKey("Comment")]
        public int? CommentId { get; set; }

        public int VoteType { get; set; } //A 0 = a downvote, a 1 = an upvote
    }
}
