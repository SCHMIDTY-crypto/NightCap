using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IModeratorDAO
    {
        Moderator GetModerator(string forumName);

        Moderator AddModerator(int userID, string username, string forumName);

        bool IsModerator(int userId, int forumId);
    }
}
