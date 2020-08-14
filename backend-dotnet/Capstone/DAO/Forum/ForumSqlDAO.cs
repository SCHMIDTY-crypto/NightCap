using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using NinjaNye.SearchExtensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class ForumSqlDAO : IForumDAO
    {
        private readonly string connectionString;

        public ForumSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public Forum GetForumById(int forumID)
        {
            Forum forum;
            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {

                    forum = nightCapDBContext.Forums.Where<Forum>(f => f.ID == forumID).SingleOrDefault();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return forum;
        }
        public Forum GetForumByName(string name)
        {
            Forum forum;
            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {

                    forum = nightCapDBContext.Forums.Where<Forum>(f => f.Title == name).SingleOrDefault();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return forum;
        }
        public List<Forum> GetForumBySearchString(string search)
        {
            List<Forum> forums = new List<Forum>();
            search = search.ToLower();
            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    if (nightCapDBContext.Forums.Any(f => f.Title.ToLower().Contains(search) || f.Body.ToLower().Contains(search)))
                    {
                        forums = nightCapDBContext.Forums.Where(f => f.Title.Contains(search) || f.Body.Contains(search)).ToList();
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return forums;
        }
        public Forum AddForum(Forum forum)
        {
            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    nightCapDBContext.Forums.Add(forum);
                    nightCapDBContext.SaveChanges();

                }
            }
            catch (SqlException)
            {
                throw;
            }
            return forum;
        }
        public List<Forum> ListForums()
        {
            List<Forum> forumList;

            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    forumList = nightCapDBContext.Forums.ToList();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return forumList;
        }
        public bool DoesForumExist(Forum forum)
        {
            bool doesExist = false;

            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    if (nightCapDBContext.Forums.Any(f => f.Title == forum.Title))
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
        public List<Forum> ListActiveForums()
        {
            PostSqlDAO postSqlDAO = new PostSqlDAO(connectionString);
            List<Post> posts = postSqlDAO.ListPosts();
            List<Forum> activeForums = new List<Forum>();

            Post[] sortedPosts = posts.OrderByDescending(o => o.Date).ToArray();

            for (int i = 0; activeForums.Count() < 5; i++)
            {
                Forum checkForum = GetForumById(sortedPosts[i].ForumId);

                if (!activeForums.Any(f => f.ID == checkForum.ID))
                {
                    activeForums.Add(checkForum);
                }

                checkForum = new Forum();

            }
            return activeForums;
        }
    }
}
