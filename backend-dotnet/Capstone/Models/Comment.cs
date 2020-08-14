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
    [Table("Comment")]
    public class Comment : Base
    {
        [Required]
        [ForeignKey("Post")]
        public int PostId { get; set; }

        [Column("ParentId")]
        public int? ParentId { get; set; }

        [Required]
        public string Author { get; set; }

    }
}
