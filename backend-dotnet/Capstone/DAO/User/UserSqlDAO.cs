using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class UserSqlDAO : IUserDAO
    {
        private readonly string connectionString;

        public UserSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public User GetUser(string username)
        {
            User returnUser = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT user_id, username, password_hash, salt, user_role, profilePicture FROM users WHERE username = @username", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        returnUser = GetUserFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnUser;
        }

        public User AddUser(string username, string password, string role, string profilePicture)
        {
            IPasswordHasher passwordHasher = new PasswordHasher();
            PasswordHash hash = passwordHasher.ComputeHash(password);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO users (username, password_hash, salt, user_role, profilePicture) VALUES (@username, @password_hash, @salt, @user_role, @profilePicture)", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password_hash", hash.Password);
                    cmd.Parameters.AddWithValue("@salt", hash.Salt);
                    cmd.Parameters.AddWithValue("@user_role", role);
                    cmd.Parameters.AddWithValue("@profilePicture", profilePicture);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return GetUser(username);
        }

        public bool SetUserAsModerator(int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = conn.CreateCommand();
                    SqlTransaction transaction = conn.BeginTransaction();

                    cmd.Connection = conn;
                    cmd.Transaction = transaction;

                    cmd.Parameters.AddWithValue("@user_id", userId);

                    cmd.CommandText = "UPDATE users SET user_role = 'moderator' WHERE user_id = @user_id";

                    bool isUpdated = cmd.ExecuteNonQuery() > 0;
                    transaction.Commit();

                    if (isUpdated)
                    {
                        return true;
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return false;
        }

        private User GetUserFromReader(SqlDataReader reader)
        {
            User u = new User()
            {
                UserId = Convert.ToInt32(reader["user_id"]),
                Username = Convert.ToString(reader["username"]),
                PasswordHash = Convert.ToString(reader["password_hash"]),
                Salt = Convert.ToString(reader["salt"]),
                Role = Convert.ToString(reader["user_role"]),
                ProfilePicture = Convert.ToString(reader["profilePicture"])
            };

            return u;
        }
    }
}
