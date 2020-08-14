using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public abstract class Base
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
