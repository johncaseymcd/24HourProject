using _24HourProject.Data;
using _24HourProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Services
{
    public class ReplyService
    {
        private readonly Guid _userID;

        public ReplyService(Guid id)
        {
            _userID = id;
        }

       public bool CreateReply(ReplyCreate model)
       {
            using (var ctx = new ApplicationDbContext())
            {
                var user =
                    ctx.User
                    .Single(e => e.UniqueID == _userID);

                var entity = new Reply()
                {
                    Content = model.Reply,
                    UserId = user.UserID,
                    CreatedUTC = model.CreatedUTC
                };

                ctx.Replies.Add(entity);
                return ctx.SaveChanges() > 0;
            }
       }

       public Reply GetReplyByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.ReplyId == id);

                return entity;
            }
        }

        public IEnumerable<ReplyListItem> GetRepliesByUserID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Replies
                    .Where(e => e.UserId == id)
                    .Select(
                        e =>
                            new ReplyListItem
                            {
                                Text = e.Content,
                                CreatedUTC = e.CreatedUTC
                            }
                    );

                return query.ToList<ReplyListItem>();
            }
        }

        public IEnumerable<ReplyListItem> GetRepliesByCommentID(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                ctx.Replies
                .Where(e => e.CommentID == id)
                .Select(
                    e =>
                        new ReplyListItem
                        {
                            Text = e.Content,
                            CreatedUTC = e.CreatedUTC
                        }
                );

                return query.ToList<ReplyListItem>();
            }            
        }

        public bool UpdateReply(ReplyDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetReplyByID(model.ReplyId);

                entity.Content = model.Content;
                entity.ModifiedUTC = model.ModifiedUTC;

                return ctx.SaveChanges() > 0;
            }
        }

        public bool DeleteReply(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetReplyByID(id);

                ctx.Replies.Remove(entity);

                return ctx.SaveChanges() > 0;
            }
        }
    }
}
