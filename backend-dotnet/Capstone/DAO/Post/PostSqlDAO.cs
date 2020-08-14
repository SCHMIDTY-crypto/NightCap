
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class PostSqlDAO : IPostDAO
    {
        private readonly string connectionString;

        public PostSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Post AddPost(Post post)
        {
            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    nightCapDBContext.Posts.Add(post);
                    nightCapDBContext.SaveChanges();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return post;
        }

        public Post GetPost(int postID)
        {
            Post post;
            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {

                    post = nightCapDBContext.Posts.Where<Post>(f => f.ID == postID).SingleOrDefault();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return post;
        }

        public Post AddImage(Post post)
        {
            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    Post updatedPost = nightCapDBContext.Posts.Single<Post>(p => p.ID == post.ID);
                    updatedPost.IMG_URL = post.IMG_URL;
                    nightCapDBContext.SaveChanges();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return post;
        }
        public List<Post> ListPosts()
        {
            List<Post> posts;

            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    posts = nightCapDBContext.Posts.ToList();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return posts;
        }

        public List<Post> ListPostsByForum(int forumId)
        {
            List<Post> forumPosts = new List<Post>();

            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    forumPosts = nightCapDBContext.Posts.Where(p => p.ForumId == forumId).ToList();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return forumPosts;
        }
        public bool DeletePost(int postId)
        {
            bool isDeleted = false;
            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    Post post = nightCapDBContext.Posts.Find(postId);
                    nightCapDBContext.Remove(post);
                    nightCapDBContext.SaveChanges();
                    isDeleted = true;
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return isDeleted;
        }
    }
}
