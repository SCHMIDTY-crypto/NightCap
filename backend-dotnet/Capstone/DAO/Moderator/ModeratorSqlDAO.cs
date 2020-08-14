using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class ModeratorSqlDAO : IModeratorDAO
    {
        private readonly string connectionString;

        public ModeratorSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Moderator GetModerator(string forumName)
        {
            Moderator moderator;
            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {

                    moderator = nightCapDBContext.Moderators.Where<Moderator>(m => m.ForumName == forumName).SingleOrDefault();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return moderator;
        }

        public Moderator AddModerator(int userID, string username, string forumName)
        {
            Moderator moderator;
            ForumSqlDAO forumSqlDAO = new ForumSqlDAO(connectionString);
            Forum forum = forumSqlDAO.GetForumByName(forumName);
            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    moderator = new Moderator() { UserId = userID, Username = username, ForumName = forumName };
                    if (!IsModerator(moderator.UserId, forum.ID))
                    {
                        nightCapDBContext.Moderators.Add(moderator);
                        nightCapDBContext.SaveChanges();
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return moderator;
        }
        public bool IsModerator(int userId, int forumId)
        {
            bool isMod = false;

            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {

                    if(nightCapDBContext.Moderators.Any(m => m.UserId == userId && m.ForumId == forumId))
                    {
                        isMod = true;
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return isMod;
        }
    }
}
