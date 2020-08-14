using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IForumDAO
    {
        Forum AddForum(Forum forum);

        List<Forum> ListForums();

        List<Forum> ListActiveForums();

        Forum GetForumById(int forumID);

        Forum GetForumByName(string name);

       List<Forum> GetForumBySearchString(string search);

        bool DoesForumExist(Forum forum);
    }
}
