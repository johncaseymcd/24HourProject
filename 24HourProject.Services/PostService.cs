using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24HourProject.Data;
using _24HourProject.Models;

namespace _24HourProject.Services
{
    public class PostService
    {
        private readonly Guid _postID;
        public PostService(Guid postID)
        {
            _postID = postID;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity = new Post
            {
                Text = model.Text,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<Post> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Posts.ToList<Post>();
            }
        }

        public Post GetPostByID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Posts
                    .Single(e => e.PostID == id);

                return entity;
            }
        }

        public IEnumerable<PostListItem> GetPostsByUserID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Posts
                    .Where(e => e.Author == id)
                    .Select(
                        e => new PostListItem
                        {
                            PostID = e.PostID,
                            Text = e.Text,
                            Author = e.Author,
                            CreatedUTC = e.CreatedUtc
                        }
                    );

                return query.ToList<PostListItem>();
            }
        }

        public bool UpdatePost(PostDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetPostByID(model.PostId);

                entity.Text = model.Text;
                entity.ModifiedUtc = model.ModifiedUtc;

                return ctx.SaveChanges() > 0;
            }
        }

        public bool DeletePost(Guid id)
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
