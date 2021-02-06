using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using _24HourProject.Services;

namespace _24HourProject.Controllers
{
    [Authorize]
    public class CommentsController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var userId = int.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }
        public IHttpActionResult Get(int id)
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetCommentByID(id);
            return Ok(comments);
        }
    }
}
