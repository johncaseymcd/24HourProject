using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Data
{
    public class User
    {
        [Key]        
        public Guid UserID { get; set; }
        
        [Required]
        [Display(Name = "Enter Name")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Enter Email")]
        public string Email { get; set; }

        [Required]
        [ForeignKey(nameof(Comment))]
        public Guid CommnetId { get; set; }
        public virtual Comment Comment { get; set; }

        [Required]
        [ForeignKey(nameof(Post))]
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }

        [Required]
        [ForeignKey(nameof(Reply))]
        public Guid ReplyId { get; set; }
        public virtual Reply Reply { get; set; }
    }  
}