using PocketDAL;
using PocketModel.People;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace PocketBusiness.People
{
    public class UserBiz : IUser
    {
        public HttpResponseMessage Authenticate(AuthenticateRequest req)
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

        public HttpResponseMessage CreateUser(User req)
        {
            HttpResponseMessage resp = new HttpResponseMessage();
            resp.StatusCode = HttpStatusCode.BadRequest;

            if (req != null)
            {
                using (var ctx = new PocketContext())
                {
                    if (ctx.Users.FirstOrDefault(x => x.Email.ToLower() == req.Email.ToLower()) != null)
                    {
                        resp.StatusCode = HttpStatusCode.Conflict;
                        resp.Content = new StringContent("Email already in use");
                    }
                    else
                    {
                        try
                        {
                            ctx.Users.Add(req);
                            ctx.SaveChanges();
                            resp.StatusCode = HttpStatusCode.OK;
                        }
                        catch (DbEntityValidationException e)
                        {
                            resp.StatusCode = HttpStatusCode.BadRequest;
                            resp.Content = new StringContent("Application could not create your profile" + e.Message);
                        }
                    }
                }
            }

            return resp;
        }
    }
}