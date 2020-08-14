using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class CommentSqlDAO : ICommentDAO
    {
        private readonly string connectionString;

        public CommentSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Comment AddComment(Comment comment)
        {
            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    nightCapDBContext.Comments.Add(comment);
                    nightCapDBContext.SaveChanges();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return comment;
        }

        public List<Comment> ListCommentsByPost(int postId)
        {
            List<Comment> comments = new List<Comment>();

            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    comments = nightCapDBContext.Comments.Where(c => c.PostId == postId).ToList();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return comments;
        }

        public bool DeleteComment(int commentId)
        {
            bool isDeleted = false;
            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    Comment comment = nightCapDBContext.Comments.Find(commentId);
                    nightCapDBContext.Remove(comment);
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
