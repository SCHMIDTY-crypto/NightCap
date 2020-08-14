using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class VoteSqlDAO : IVoteDAO
    {
        private readonly string connectionString;

        public VoteSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Vote AddVote(Vote vote)
        {
            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    nightCapDBContext.Votes.Add(vote);
                    nightCapDBContext.SaveChanges();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return vote;
        }

        public bool HasVoted(Vote vote)
        {
            bool hasVoted = false;

            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    if (DoesVotesExist(vote))
                    {
                        hasVoted = true;
                    }
                }
            }
            catch (SqlException)
            {

                throw;
            }
            return hasVoted;
        }

        public bool DoesVotesExist(Vote newVote)
        {
            bool doesExist = false;
            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    if (nightCapDBContext.Votes.Any(v => v.UserId == newVote.UserId && v.PostId == newVote.PostId))
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

        public List<Vote> GetVotesByPost(int postId)
        {
            List<Vote> votes = new List<Vote>();
            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    votes = nightCapDBContext.Votes.Where(v => v.PostId == postId).ToList();
                }
            }
            catch (SqlException)
            {

                throw;
            }
            return votes;
        }
    }
}
