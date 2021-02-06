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
        public Guid PostID { get; set; }

        [Required]
        [Display(Name = "Post")]
        public string Title { get; set; }

        [Required]
        [MaxLength(512, ErrorMessage = "Max character reached")]
        public string Text { get; set; }

        [Required]
        public virtual List<Comment> Comments { get; set; }            

        [Required]
        public Guid Author { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        [Required]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}

