using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    [Table("UpdatedComment")]
    public class UpdatedComment :Base
    {
        [Required]
        [ForeignKey("Comment")]
        public int CommentId { get; set; }
    }
}
