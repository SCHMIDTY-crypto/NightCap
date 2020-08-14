using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    [Table("user_forum_moderator")]
    public class Moderator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RelationID { get; set; }

        [Required]
        [ForeignKey("users")]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [NotMapped]
        public int? ForumId => GetForumId(ForumName);

        [Required]
        [ForeignKey("Title")]
        public string ForumName { get; set; }

        private int GetForumId(string forumName)
        {
            Forum forum;
            try
            {
                using (NightCapDBContext nightCapDBContext = new NightCapDBContext())
                {

                    forum = nightCapDBContext.Forums.Where<Forum>(f => f.Title == forumName).SingleOrDefault();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return forum.ID;
        }
    }
}
