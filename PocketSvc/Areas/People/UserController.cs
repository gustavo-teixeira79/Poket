using PocketBusiness.People;
using PocketModel.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PocketSvc.Areas.People
{
    public class UserController : ApiController
    {
        private IUser userModule;

        public UserController(IUser user)
        {
            this.userModule = user;
        }

        [HttpPost]
        public HttpResponseMessage Authenticate([FromBody] AuthenticateRequest req)
        {
            HttpResponseMessage resp = new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest };
            if (req != null || (string.IsNullOrEmpty(req.Email) && string.IsNullOrEmpty(req.Password)))
            {
                resp = this.userModule.Authenticate(req);
            }
            return resp;
            
        }

    }
}
