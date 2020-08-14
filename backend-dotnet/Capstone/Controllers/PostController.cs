using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostDAO postDAO;
        private readonly ICommentDAO commentDAO;
        private readonly IVoteDAO voteDAO;
        private readonly IUserDAO userDAO;
        private readonly IModeratorDAO moderatorDAO;

        public PostController(IPostDAO _postDAO, ICommentDAO _commentDAO, IVoteDAO _voteDAO, IUserDAO _userDAO, IModeratorDAO _moderatorDAO)
        {
            postDAO = _postDAO;
            commentDAO = _commentDAO;
            voteDAO = _voteDAO;
            userDAO = _userDAO;
            moderatorDAO = _moderatorDAO;
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Post> AddPost(Post newPost)
        {
            Post post = postDAO.AddPost(newPost);
            if (post != null)
            {
                return Ok(post);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Authorize]
        public ActionResult<Post> AddImage(Post post)
        {
            if (post != null)
            {
                Post updatedPost = postDAO.AddImage(post);
                return Ok(updatedPost);
            }
            else return NotFound();
        }

        [HttpGet("{postId}/comments")]
        public List<Comment> GetComments(int postId)
        {
            return commentDAO.ListCommentsByPost(postId);
        }

        [HttpGet("{postId}/votes")]
        public List<Vote> GetVotes(int postId)
        {
            return voteDAO.GetVotesByPost(postId);
        }

        [HttpPost("{postId}/votes")]
        [Authorize]
        public ActionResult<Vote> AddVote(Vote vote)
        {
            if (!voteDAO.HasVoted(vote))
            {
                voteDAO.AddVote(vote);
                return Ok(vote);
            }
            return StatusCode(409);
        }
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteComment(JObject jObject)
        {
            dynamic info = jObject;
            User user = userDAO.GetUser((string)info.username);
            if (user.Role == "admin")
            {
                if (postDAO.DeletePost((int)info.postId))
                {
                    return StatusCode(204);
                }
                else return NotFound();
            }
            else if (moderatorDAO.IsModerator((int)info.userId, (int)info.forumId))
            {
                if (postDAO.DeletePost((int)info.postId))
                {
                    return StatusCode(204);
                }
                else return NotFound();
            }
            else return StatusCode(401);
        }

    }
}
