using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IFavoriteForumDAO
    {
        FavoriteForum AddFavorite(FavoriteForum favoriteForum);

        List<Forum> GetFavorites(int userId);

        bool DoesFavoriteExist(FavoriteForum favorite);
    }
}
