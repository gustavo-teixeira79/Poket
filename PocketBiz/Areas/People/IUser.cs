using PocketModel.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PocketBiz.Areas.People
{
    public interface IUser
    {
        HttpResponseMessage Authenticate(AuthenticateRequest req);
    }
}
