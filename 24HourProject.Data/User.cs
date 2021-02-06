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
        public int UserID { get; set; }
        public Guid UniqueID { get; set; }
        
        [Required]
        [Display(Name = "Enter Name")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Enter Email")]
        public string Email { get; set; }
    }  
}