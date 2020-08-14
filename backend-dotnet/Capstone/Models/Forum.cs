using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.SqlClient;

namespace Capstone.Models
{
    [Table("Forum")]
    public class Forum : Base
    {
        [NotMapped]
        public List<Moderator> Moderators => GetModerators(Title);

        private List<Moderator> GetModerators(string forumName)
        {
            List<Moderator> moderators;

            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {
                    moderators = nightCapDBContext.Moderators.Where(m => m.ForumName == forumName).ToList();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return moderators;
        }
    }
}
