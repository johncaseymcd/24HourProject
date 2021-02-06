using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Data
{
    public class Reply : Comment
    {
        [Key]
        public int ReplyId { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public Post UserId { get; set; }
        public virtual Post User { get; set; }

        [ForeignKey(nameof(Post))]
        public Post PostId { get; set; }
        public virtual Post Post { get; set; }

        public Comment ReplyComment { get; set; }
        public string Content { get; set; }        
    }
}


