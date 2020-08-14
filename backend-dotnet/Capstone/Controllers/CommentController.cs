using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml.Serialization;
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
    public class CommentController : ControllerBase
    {
        private readonly ICommentDAO commentDAO;
        private readonly IUserDAO userDAO;
        private readonly IModeratorDAO moderatorDAO;

        public CommentController(ICommentDAO _commentDAO, IUserDAO _userDAO, IModeratorDAO _moderatorDAO)
        {
            commentDAO = _commentDAO;
            userDAO = _userDAO;
            moderatorDAO = _moderatorDAO;
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult<Comment> AddComment(Comment newComment)
        {
            Comment comment = commentDAO.AddComment(newComment);
            if (comment != null)
            {
                return Ok(comment);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Authorize]
        public ActionResult DeleteComment(JObject jObject)
        {
            dynamic info = jObject;
            User user = userDAO.GetUser((string)info.username);
            if (user.Role == "admin")
            {
                if (commentDAO.DeleteComment((int)info.commentId))
                {
                    return StatusCode(204);
                }
                else return NotFound();
            }
            else if (moderatorDAO.IsModerator((int)info.userId, (int)info.forumId))
            {
                if (commentDAO.DeleteComment((int)info.commentId))
                {
                    return StatusCode(204);
                }
                else return NotFound();
            }
            else return StatusCode(401);
        }
    }
}
