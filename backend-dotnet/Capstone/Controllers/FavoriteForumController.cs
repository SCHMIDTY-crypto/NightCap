using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class FavoriteForumController : ControllerBase
    {
        private readonly IFavoriteForumDAO favoriteForumDAO;

        public FavoriteForumController(IFavoriteForumDAO _favoriteForumDAO)
        {
            favoriteForumDAO = _favoriteForumDAO;
        }

        [HttpPost]
        public ActionResult AddFavorite(FavoriteForum newFavoriteForum)
        {
            if (!favoriteForumDAO.DoesFavoriteExist(newFavoriteForum))
            {
                FavoriteForum favoriteForum = favoriteForumDAO.AddFavorite(newFavoriteForum);
                if (favoriteForum != null)
                {
                    return Ok(favoriteForum);
                }
            }
            return StatusCode(409);
        }

        [HttpGet("{userId}")]
        public List<Forum> GetFavorites(int userId)
        {
            return favoriteForumDAO.GetFavorites(userId);
        }
    }
}