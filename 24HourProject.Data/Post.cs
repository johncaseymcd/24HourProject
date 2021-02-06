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

        [Required]
        [Display(Name = "Post")]
        public string Title { get; set; }

        [Required]
        [MaxLength(512, ErrorMessage = "Max character reached")]
        public string Text { get; set; }
        //public virtual List<Comment> Comments { get; set; } = new List<Comment>();

        public Guid Author { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}

