using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IPostDAO
    {
        Post AddPost(Post post);
        List<Post> ListPostsByForum(int forumId);
        Post AddImage(Post post);
        bool DeletePost(int postId);
    }
}
