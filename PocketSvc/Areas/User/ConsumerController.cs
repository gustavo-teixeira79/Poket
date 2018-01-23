using PocketDAL;
using PocketModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PocketSvc.Areas.User
{
    public class ConsumerController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage ValidateConsumer([FromBody] AuthenticateRequest req)
        {
            HttpResponseMessage resp = new HttpResponseMessage();
            resp.StatusCode = HttpStatusCode.BadRequest;

            if (string.IsNullOrEmpty(req.Email) || string.IsNullOrEmpty(req.Password))
            {
                return resp;
            }

            using (var ctx = new PocketContext())
            {
                if (ctx.Users.FirstOrDefault(x => x.Email.ToLower() == req.Email.ToLower() && x.Password == req.Password) == null)
                {
                    resp.StatusCode = HttpStatusCode.Forbidden;
                }
                else
                {
                    resp.StatusCode = HttpStatusCode.OK;
                }
            }

            return resp;
        }
    }
}
