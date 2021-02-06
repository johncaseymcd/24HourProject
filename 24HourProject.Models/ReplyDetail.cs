using _24HourProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Models
{
    public class ReplyDetail
    {
        [Required]
        public int ReplyId { get; set; }
        public Guid Author { get; set; }
        [Required]
        public Comment ReplyComment { get; set; }
        public string Content { get; set; }
        public DateTimeOffset ModifiedUTC { get; set; }
    }
}
