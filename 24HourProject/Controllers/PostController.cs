using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using _24HourProject.Services;
using Microsoft.AspNet.Identity;

namespace _24HourProject.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        private PostService CreatePostService()
        {
            var postId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(postId);
            return postService;
        }
    }
    public IHttpActionResult Get()
    {
        PostService postService = CreatePostService();
        var posts = postService.GetPosts();
        return Ok(posts);

    }
    public IHttpActionResult Post(PostCreate post)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var service = CreatePostService();

        if (!service.CreatePost(post))
            return InternalServerError();

        return Ok();
    }
}
