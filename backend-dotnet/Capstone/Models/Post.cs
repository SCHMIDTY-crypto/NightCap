using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Capstone.Models
{
    [Table("Post")]
    public class Post : Base
    {
        [Required]
        [ForeignKey("Forum")]
        public int ForumId { get; set; }

        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }

        public string IMG_URL { get; set; }

        public string Author { get; set; }
    }
}
