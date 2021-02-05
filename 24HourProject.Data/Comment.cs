using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Data
{

    public class Comment
    {
        [Key]
        public int CommentId { get; set; }                                         
        [MaxLength(64, ErrorMessage = "Max character reached")]        
        public string Text { get; set; }               
        [Required]
        [ForeignKey(nameof(UserId))]
        public Guid UserId { get; set; }           
       
        [Required]
        public virtual Reply Reply { get; set; }
        
        [Required]
        [ForeignKey(nameof(Commet))]
        public int PostId { get; set; }
        public virtual Comment Commet { get; set; }
    }

    public class Reply : Comment
    {
        [Required]
        public int ReplyCommentID { get; set; }
    }
}
