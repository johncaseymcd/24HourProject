using _24HourProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HourProject.Controllers
{
    public class ReplyController : ApiController
    {
        public IHttpActionResult Get(Guid id)
        {
            ReplyService replyService = CreateReplyService();
            var reply = replyService.GetReplyByID(id);
            return Ok(reply);
        }
    }
}
