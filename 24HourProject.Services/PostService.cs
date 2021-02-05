using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24HourProject.Data;

namespace _24HourProject.Services
{
    public class PostService
    {
        public bool CreatePost(PostCreate model)
        {
            var entity = new Post
            {
                Text = model.Text,
                Author = model.Author,
                CreatedUTC = model.CreatedUTC
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<Post> GetAllPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Posts.ToList<Post>();
            }
        }

        public Post GetPostByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Posts
                    .Single(e => e.PostID == id);

                return entity;
            }
        }

        public IEnumerable<Post> GetPostsByUserID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Posts
                    .Where(e => e.UserID == id)
                    .Select(
                        e => new PostListItem
                        {
                            PostID = e.PostID,
                            Text = e.Text,
                            Author = e.UserID,
                            CreatedUTC = e.CreatedUTC
                        }
                    );

                return query.ToList<Post>();
            }
        }

        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetPostByID(model.PostID);

                entity.Text = model.text;
                entity.ModifiedUTC = model.ModifiedUTC;

                return ctx.SaveChanges() > 0;
            }
        }

        public bool DeletePost(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetPostByID(id);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() > 0;
            }
        }
    }
}
