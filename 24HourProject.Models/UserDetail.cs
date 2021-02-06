using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Models
{
    public class UserDetail
    {
        [Required]
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
