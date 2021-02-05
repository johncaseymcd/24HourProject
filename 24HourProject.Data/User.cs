using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }

    test
}