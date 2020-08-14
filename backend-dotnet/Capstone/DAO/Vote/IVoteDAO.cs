using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IVoteDAO
    {
        Vote AddVote(Vote vote);
        List<Vote> GetVotesByPost(int postId);
        bool HasVoted(Vote vote);
    }
}
