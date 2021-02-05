using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Data
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }

        [Display(Name = "Post")]
        public string Title { get; set; }

        [MaxLength(512, ErrorMessage = "Max character reached")]
        public string Text { get; set; }

        public List<Comment> Comments { get; set; }

        [Required]
        public Guid Author { get; set; }
    }
}

