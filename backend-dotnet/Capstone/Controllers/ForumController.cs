using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
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
    public class ForumController : ControllerBase
    {
        private readonly IForumDAO forumDAO;
        private readonly IPostDAO postDAO;
        private readonly IUserDAO userDAO;
        private readonly IModeratorDAO moderatorDAO;

        public ForumController(IForumDAO _forumDAO, IPostDAO _postDAO, IUserDAO _userDAO, IModeratorDAO _moderatorDAO)
        {
            forumDAO = _forumDAO;
            postDAO = _postDAO;
            userDAO = _userDAO;
            moderatorDAO = _moderatorDAO;
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddForum(JObject jObject)
        {
            dynamic info = jObject;
            //bool isUpdated = userDAO.SetUserAsModerator((int)info.userId);
            //moderatorDAO.AddModerator((int)info.userId, (string)info.username, (string)info.title);
            Forum newForum = new Forum
            {
                Title = (string)info.title,
                Body = (string)info.body
            };

            if (!forumDAO.DoesForumExist(newForum))
            {
                if (newForum != null)
                {
                    forumDAO.AddForum(newForum);
                    userDAO.SetUserAsModerator((int)info.userId);
                    moderatorDAO.AddModerator((int)info.userId, (string)info.username, (string)info.title);
                    return Ok(newForum);
                }                
            }
            return StatusCode(409);
        }

        [HttpGet]
        public List<Forum> ListForums()
        {
            return forumDAO.ListForums();
        }

        [HttpGet("{forumId}")]
        public ActionResult<Forum> GetForumById(int forumId)
        {
            Forum forum = forumDAO.GetForumById(forumId);
            if (forum != null)
            {
                return Ok(forum);
            }
            else return NotFound();
        }

        [HttpGet("{forumID}/posts")]
        public List<Post> ListPostsByForum(int forumID)
        {
            return postDAO.ListPostsByForum(forumID);
        }

        [HttpGet("{forumID}/moderators")]
        public List<Moderator> LisetModeratorsByForum(int forumID)
        {
            return forumDAO.GetForumById(forumID).Moderators;
        }

        [HttpPost("{forumID}/moderators")]
        public ActionResult AddModerator(Moderator moderator)
        {
            Forum forum = forumDAO.GetForumByName(moderator.ForumName);
            if(!moderatorDAO.IsModerator(moderator.UserId, forum.ID))
            {
                moderatorDAO.AddModerator(moderator.UserId, moderator.Username, moderator.ForumName);
                return Ok(moderator);
            }
            else return StatusCode(409);
        }

        [HttpGet("search")]
        public List<Forum> GetForumBySearch(string searchString)
        {
            List<Forum> forums = forumDAO.GetForumBySearchString(searchString);
            if (forums != null)
            {
                return forums;
            }
            else return null;
        }

        [HttpGet("active")]
        public List<Forum> GetActiveForums()
        {
            return forumDAO.ListActiveForums();
        }
    }
}