using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    [Table("user_forum_favorite")]
    public class FavoriteForum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [ForeignKey("users")]
        public int UserId { get; set; }
        [ForeignKey("Forum")]
        public int ForumId { get; set; }
    }
}
