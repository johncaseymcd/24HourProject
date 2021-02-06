using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Data
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        [ForeignKey(nameof(Comment))]
        public int CommentID { get; set; }
        public virtual Comment Comment { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}


