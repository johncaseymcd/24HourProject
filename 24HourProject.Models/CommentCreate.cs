using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _24HourProject.Models
{
    public class CommentCreate
    {
        [Required]
        public string Text { get; set; }

    }
}
