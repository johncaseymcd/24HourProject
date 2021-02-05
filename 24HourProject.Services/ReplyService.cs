using _24HourProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Services
{
    public class ReplyService
    {
       public bool CreateReply(ReplyCreate model)
       {
            var entity = new ReplyService()
            {
                Text = model.Text,
                Author = model.UserID,
                CreatedUTC = model.CreatedUTC
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() > 0;
            }
       }

        public IEnumerable<Reply> GetAllReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Replies.ToList<Reply>();
            }
        }

        public Reply GetReplyByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.ReplyID == id);

                return entity;
            }
        }

        public IEnumerable<Reply> GetRepliesByUserID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Replies
                    .Where(e => e.UserID == id)
                    .Select(
                        e =>
                            new ReplyListItem
                            {
                                ReplyID = e.ReplyID,
                                Text = e.Text,
                                CreatedUTC = e.CreatedUTC
                            }
                    );

                return query.ToList<Reply>();
            }
        }

        public IEnumerable<Reply> GetRepliesByCommentID(int id)
        {
            var query =
                ctx.Replies
                .Where(e => e.CommentID == id)
                .Select(
                    e =>
                        new ReplyListItem
                        {
                            ReplyID = e.ReplyID,
                            Text = e.Text,
                            CreatedUTC = e.CreatedUTC
                        }
                );

            return query.ToList<Reply>();
        }

        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetReplyByID(model.ReplyID);

                entity.Text = model.Text;
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
