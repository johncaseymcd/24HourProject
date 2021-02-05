using _24HourProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Services
{
    public class CommentService
    {
        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment
            {
                Text = model.Text,
                Author = model.UserID,
                CreatedUTC = model.CreatedUTC
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        public Comment GetCommentByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Comments
                    .Single(e => e.CommentID == id);

                return entity;
            }
        }

        public IEnumerable<Comment> GetCommentsByPostID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Comments
                    .Where(e => e.PostID == id)
                    .Select(
                        e => new CommentListItem
                        {
                            CommentID = e.CommentID,
                            Text = e.text,
                            CreatedUTC = e.CreatedUTC
                        }
                    );

                return query.ToList<Comment>();
            }
        }

        public IEnumerable<Comment> GetCommentsByUserID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Comments
                    .Where(e => e.UserID == id)
                    .Select(
                        e => new CommentListItem
                        {
                            CommentID = e.CommentID,
                            Text = e.Text,
                            CreatedUTC = e.CreatedUTC
                        }
                    );

                return query.ToList<Comment>();
            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetCommentByID(model.CommentID);

                entity.Text = model.Text;
                entity.ModifiedUTC = model.ModifiedUTC;

                return ctx.SaveChanges() > 0;
            }
        }

        public bool DeleteComment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetCommentByID(id);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() > 0;
            }
        }
    }
}
