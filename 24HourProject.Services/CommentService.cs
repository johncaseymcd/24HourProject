using _24HourProject.Data;
using _24HourProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace _24HourProject.Services
{
    public class CommentService
    {
        private readonly Guid _commentID;
        
        public CommentService(Guid id)
        {
            _commentID = id;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment
            {
                CommentId = _commentID,
                Text = model.Text
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        public Comment GetCommentByID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Comments
                    .Single(e => e.CommentId == id);

                return entity;
            }
        }

        public IEnumerable<CommentListItem> GetCommentsByPostID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Comments
                    .Where(e => e.PostId == id)
                    .Select(
                        e => new CommentListItem
                        {
                            Text = e.Text,
                            CreatedUTC = e.CreatedUtc
                        }
                    );

                return query.ToList<CommentListItem>();
            }
        }

        public IEnumerable<CommentListItem> GetCommentsByUserID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Comments
                    .Where(e => e.UserId == id)
                    .Select(
                        e => new CommentListItem
                        {
                            Text = e.Text,
                            CreatedUTC = e.CreatedUtc
                        }
                    );

                return query.ToList<CommentListItem>();
            }
        }

        public bool UpdateComment(CommentDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetCommentByID(model.CommentId);

                entity.Text = model.Text;
                entity.ModifiedUtc = model.ModifiedUtc;

                return ctx.SaveChanges() > 0;
            }
        }

        public bool DeleteComment(Guid id)
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
