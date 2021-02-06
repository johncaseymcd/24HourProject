using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Models
{
    public class ReplyCreate
    {
        [Required]
        public Guid Author { get; set; }
        [Required]
        public string Reply { get; set; }
    }
}
