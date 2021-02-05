using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _24HourProject.Services;
using Microsoft.AspNet.Identity;

namespace _24HourProject.Controllers
{
    [Authorize]
    public class CommentsController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            CommentService commentService = CreateCommentService();
            var comment = commentService.GetCommentById(id);
            return Ok(comment);
        }
    }
}
