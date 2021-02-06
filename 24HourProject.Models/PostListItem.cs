using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Models
{
    public class PostListItem
    {
        [Required]
        public Guid PostID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid Author { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
