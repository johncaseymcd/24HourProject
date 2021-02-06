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
        private readonly Guid _replyID;

        public ReplyService(Guid id)
        {
            _replyID = id;
        }

       public bool CreateReply(ReplyCreate model)
       {
            var entity = new Reply()
            {
                Content = model.Reply,
                UserId = model.Author,
                CreatedUTC = model.CreatedUTC
            };

            using (var ctx = new ApplicationDbContext())
            {
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

        public IEnumerable<ReplyListItem> GetRepliesByUserID(Guid id)
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

        public IEnumerable<ReplyListItem> GetRepliesByCommentID(Guid id)
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
