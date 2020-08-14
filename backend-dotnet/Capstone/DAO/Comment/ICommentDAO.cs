using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface ICommentDAO
    {
        Comment AddComment(Comment comment);

        List<Comment> ListCommentsByPost(int postId);

        bool DeleteComment(int commentId);
    }
}
