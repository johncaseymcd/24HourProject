using _24HourProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Models
{
    public class ReplyListItem
    {
        [Required]
        public int ReplyId { get; set; }
        public Comment ReplyComment { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
