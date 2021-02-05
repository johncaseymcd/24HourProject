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
        public IHttpActionResult Get(int id)
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetCommentByID(id);
            return Ok(comments);
        }
    }
}
