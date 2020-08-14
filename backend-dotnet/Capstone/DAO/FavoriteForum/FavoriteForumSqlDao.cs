using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public class FavoriteForumSqlDao : IFavoriteForumDAO
    {
        private readonly string connectionString;

        public FavoriteForumSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public FavoriteForum AddFavorite(FavoriteForum favoriteForum)
        {
            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    nightCapDBContext.FavoriteForums.Add(favoriteForum);
                    nightCapDBContext.SaveChanges();

                }
            }
            catch (SqlException)
            {
                throw;
            }
            return favoriteForum;
        }
        public List<Forum> GetFavorites(int userId)
        {
            ForumSqlDAO forumSqlDAO = new ForumSqlDAO(connectionString);

            List<FavoriteForum> favoriteForums = new List<FavoriteForum>();
            List<Forum> forumList = new List<Forum>();

            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    favoriteForums = nightCapDBContext.FavoriteForums.Where(f => f.UserId == userId).ToList();

                    foreach (FavoriteForum forum in favoriteForums)
                    {
                        forumList.Add(forumSqlDAO.GetForumById(forum.ForumId));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return forumList;
        }
        public bool DoesFavoriteExist(FavoriteForum favorite)
        {
            bool doesExist = false;

            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    if (nightCapDBContext.FavoriteForums.Any(f => f.UserId == favorite.UserId && f.ForumId == favorite.ForumId))
                    {
                        doesExist = true;
                    }

                }
            }
            catch (SqlException)
            {
                throw;
            }
            return doesExist;

        }
    }
}
