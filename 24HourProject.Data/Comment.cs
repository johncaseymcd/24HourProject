using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Data
{

    public class Comment
    {
        [Key]
        public int CommentId { get; set; }


        // Body of comment
        public string Text { get; set; }


        // Who is writing the comment
        public Guid Author { get; set; }


        // CommentPost is which post we're commenting on
        public Post CommentPost { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}

// What is required
//int Id
//string Text
//Guid Author (using user ID)
//(virtual list of Replies)
//(Foreign Key to Post via Id w/ virtual Post)